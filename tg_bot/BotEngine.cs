using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using tg_bot.abstractions;
using tg_bot.dtos;
using tg_bot.helpers;
using tg_bot.state;

namespace tg_bot
{
    internal class BotEngine : IBotEngine
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IBookingServices _bookingServices;
        private readonly StateServices _stateService = new();
        public BotEngine(ITelegramBotClient botClient, IBookingServices bookingServices)
        {
            _botClient = botClient;
            _bookingServices = bookingServices;
        }

        // слушаем все сообщения которые отправляются на этот бот
        public async Task ListenForMessagesAsync()
        {
            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>() // получаем все обновленные типы
            };
            _botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = await _botClient.GetMeAsync();


            Console.WriteLine($"Начал свою работу бот: @{me.Username}");
            Console.ReadLine();
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message != null)
            {
                var userId = update.Message.From.Id;
                var userState = _stateService.GetUserState(userId);

                switch (userState.current_state)
                {
                    case "default":
                        await HandleDefaultState(botClient, update.Message, userState);
                        break;
                    case "help":
                        await HandleHelpState(botClient, update.Message, userState);
                        break;
                    case "registration":
                        await HandleRegistration(botClient, update.Message, userState);
                        break;
                    case "main":
                        await HandleMainState(botClient, update.Message, userState);
                        break;
                    case "select_session":
                        await HandleShowSessionPage(botClient, update.Message, userState, new List<AvailableSessionDto>());
                        break;
                    case "select_seats":
                        await HandleSelectSeat(botClient, update.Message, userState);
                        break;
                        //case "purchase_ticket":
                        //    await HandlePurchaseTicket(botClient, update.Message, userState);
                        //    break;
                }
            }
            else if (update.CallbackQuery != null)
            {
                await HandleCallbackQueryAsync(botClient, update.CallbackQuery, cancellationToken);
            }
        }

        private async Task HandleCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery callbackQuery, CancellationToken cancellationToken)
        {
            var user_id = callbackQuery.From.Id;
            var userState = _stateService.GetUserState(user_id);

            if (callbackQuery.Data == "back")
            {
                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                userState.GoBack();

                Console.WriteLine(userState.current_state);

                switch (userState.current_state)
                {
                    case "main":
                        await HandleMainState(botClient, callbackQuery.Message, userState);
                        break;
                    case "default":
                        await HandleDefaultState(botClient, callbackQuery.Message, userState);
                        break;
                    case "select_session":
                        await HandleShowSessionPage(botClient, callbackQuery.Message, userState, userState.CachedSessions);
                        break;
                }
                return;
            }
            else if (callbackQuery.Data == "help")
            {
                userState.SetState("help");

                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);

                await HandleHelpState(botClient, callbackQuery.Message, userState);
            }
            else if (callbackQuery.Data == "register")
            {
                userState.SetState("registration");

                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);

                var replyMarkup = new ReplyKeyboardMarkup(new[] {
                        new KeyboardButton("Отправить контакт") { RequestContact = true }
                })
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                };

                await botClient.SendTextMessageAsync(
                    callbackQuery.Message.Chat.Id,
                    "Пожалуйста, отправьте номер телефона для регистрации " + EmojiHelpers.PHONE,
                    replyMarkup: replyMarkup);
                return;
            }
            else if (callbackQuery.Data == "user_tickets")
            {
                userState.SetState("user_tickets");

                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);

                var tickets = await _bookingServices.GetTicketByChatId(user_id);

                if (tickets.Count == 0 || tickets is null)
                {
                    await botClient.SendTextMessageAsync(
                    callbackQuery.Message.Chat.Id,
                    "У вас пока нет билетов :(",
                    replyMarkup: GetKeyboardForState(userState.current_state));
                }
                else
                {
                    // Форматируем билеты
                    var ticketsMessage = string.Join("\n\n", tickets.Select((ticket, index) =>
                        $"{EmojiHelpers.TICKET} **Билет {index + 1}:**\n" +
                        $"• **Фильм:** {ticket.movie_title}\n" +
                        $"• **Дата и время:** {ticket.session_start_time:dd.MM.yyyy HH:mm}\n" +
                        $"• **Место:** ряд {ticket.row_number}, место {ticket.seat_number}\n"));

                    // Отправляем сообщение
                    await botClient.SendTextMessageAsync(
                        callbackQuery.Message.Chat.Id,
                        $"Ваши билеты:\n\n{ticketsMessage}",
                        parseMode: ParseMode.Markdown,             // Для поддержания форматирования
                        replyMarkup: GetKeyboardForState(userState.current_state));
                }
                return;
            }
            else if (callbackQuery.Data == "select_session")
            {
                userState.SetState("select_session");

                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);

                userState.CachedSessions = await _bookingServices.GetAvailableSession();
                if (userState.CachedSessions.Count == 0)
                {
                    await botClient.SendTextMessageAsync(
                        callbackQuery.Message.Chat.Id,
                        "К сожалению, пока доступных сеансов нет :(",
                        replyMarkup: GetKeyboardForState(userState.current_state));
                    return;
                }
                else
                {
                    await HandleShowSessionPage(botClient, callbackQuery.Message, userState, userState.CachedSessions);
                    return;
                }
            }
            else if (callbackQuery.Data == "next_page")
            {
                userState.CurrentSessionPage++;
                await HandleShowSessionPage(botClient, callbackQuery.Message, userState, userState.CachedSessions);
                return;
            }
            else if (callbackQuery.Data == "prev_page")
            {
                userState.CurrentSessionPage--;
                await HandleShowSessionPage(botClient, callbackQuery.Message, userState, userState.CachedSessions);
                return;
            }
            else if (callbackQuery.Data.StartsWith("session_"))
            {
                userState.SetState("select_seats");
                int sessionIndex = int.Parse(callbackQuery.Data.Replace("session_", ""));
                var selectedSession = userState.CachedSessions[sessionIndex];

                var session = _bookingServices.GetSessionDetails(selectedSession.id);

                if (session.Result != null)
                {
                    // показ определенного сеанса
                    await HandleShowSessionDetails(botClient, callbackQuery.Message, userState, session.Result);
                }
                else
                {
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id,
                        "К сожалению, такого сеанса не существует, попробуйте выбрать другой сеанс.",
                        replyMarkup: GetKeyboardForState(userState.current_state));
                }
            }

        }

        private InlineKeyboardMarkup GetKeyboardForState(string currentState)
        {
            var buttons = new List<InlineKeyboardButton[]>();
            if (currentState != "main" || currentState != "default" || currentState != "registration")
            {
                buttons.Add([InlineKeyboardButton.WithCallbackData(EmojiHelpers.BACK + " Назад", "back")]);
            }
            return new InlineKeyboardMarkup(buttons);
        }

        private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Ошибка телеграмм АПИ: \n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        private async Task HandleHelpState(ITelegramBotClient botClient, Message message, UserState userState)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id,
                "Этот бот позволяет купить билеты в кинотеатр, а также просмотреть купленные билеты.",
                replyMarkup: GetKeyboardForState(userState.current_state));
        }

        private async Task HandleDefaultState(ITelegramBotClient botClient, Message message, UserState userState)
        {
            // Тут создаем нашу клавиатуру
            var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                        // Каждый новый массив - это дополнительные строки,
                        new InlineKeyboardButton[]
                        {
                            InlineKeyboardButton.WithCallbackData(char.ConvertFromUtf32(0x1F511) + " Регистрация", "register")
                        },
                        new InlineKeyboardButton[]
                        {
                            InlineKeyboardButton.WithCallbackData(char.ConvertFromUtf32(0x2753) + "Справка", "help")
                        },
                });

            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Тебя приветствует бот кинотеатра \"Смотрилка\"!" + char.ConvertFromUtf32(0x1F44B),
                replyMarkup: inlineKeyboard);
            return;
        }

        private async Task HandleRegistration(ITelegramBotClient botClient, Message message, UserState userState)
        {
            string phone_number = message?.Contact?.PhoneNumber ?? message?.Text ?? "";
            if (phone_number[0] == '7') phone_number = '+' + phone_number;

            var match = Regex.Match(
                phone_number,
                @"^(?:\+7|8)\s*\(?(\d{3})\)?[-.\s]?(\d{3})[-.\s]?(\d{2})[-.\s]?(\d{2})$"
            );
            if (match.Success)
            {
                userState.SetState("main");

                var reply = new ReplyKeyboardRemove();
                await botClient.SendTextMessageAsync(message.Chat.Id,
                    "Спасибо! Ожидайте регистрацию...", replyMarkup: reply);

                // тут будет запрос на другой сервис, регистрация пользователя
                var result = await _bookingServices.RegisterUser(message.Chat.Id, phone_number);

                if (result)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                    "Регистрация прошла успешно! Теперь вы можете купить билет в кинотеатр или просмотреть свои купленные билеты.");
                    await HandleMainState(botClient, message, userState);
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "Не удалось зарегистрировать по этому номеру телефону. Попробуйте отправить другой номер.");
                }
            }
            else
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Введите номер в корректном формате: (+7XXX-XXX-XX-XX)");
            }
        }

        private async Task HandleMainState(ITelegramBotClient botClient, Message message, UserState userState)
        {
            // Тут создаем нашу клавиатуру
            var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                        // Каждый новый массив - это дополнительные строки,
                        new InlineKeyboardButton[]
                        {
                            InlineKeyboardButton.WithCallbackData(EmojiHelpers.MONEY + " Купить билет", "select_session")
                        },
                        new InlineKeyboardButton[]
                        {
                            InlineKeyboardButton.WithCallbackData(EmojiHelpers.TICKET + " Посмотреть купленные билеты", "user_tickets")
                        },
                });

            await botClient.SendTextMessageAsync(
                message.Chat.Id,
                "Выберите подходящую услугу: ",
                replyMarkup: inlineKeyboard);
        }

        private async Task HandleShowSessionPage(ITelegramBotClient botClient, Message message, UserState userState, List<AvailableSessionDto> sessions)
        {
            int pageSize = 5; // Количество сеансов на одной странице
            int totalPages = (int)Math.Ceiling((double)sessions.Count / pageSize);

            int currentPage = userState.CurrentSessionPage;
            var pagedSessions = sessions.Skip(currentPage * pageSize).Take(pageSize).ToList();

            // Создаем кнопки для сеансов
            var buttons = pagedSessions.Select((session, index) =>
                new[]
                {
            InlineKeyboardButton.WithCallbackData(
                $"{session.title} - {session.start_time:dd.MM.yyyy HH:mm}",
                $"session_{currentPage * pageSize + index}")
                }).ToList();

            // Кнопки навигации
            var navigationButtons = new List<InlineKeyboardButton>();

            if (currentPage > 0)
                navigationButtons.Add(InlineKeyboardButton.WithCallbackData(EmojiHelpers.LEFT_ARROW + " Предыдущая", "prev_page"));

            if (currentPage < totalPages - 1)
                navigationButtons.Add(InlineKeyboardButton.WithCallbackData("Следующая " + EmojiHelpers.RIGHT_ARROW, "next_page"));

            if (navigationButtons.Count > 0)
                buttons.Add(navigationButtons.ToArray());

            // Добавляем кнопку "Назад"
            buttons.Add([InlineKeyboardButton.WithCallbackData(EmojiHelpers.BACK + " Назад", "back")]);

            var inlineKeyboard = new InlineKeyboardMarkup(buttons);

            await botClient.SendTextMessageAsync(
                message.Chat.Id,
                $"Сеансы (стр. {currentPage + 1}/{totalPages}):",
                replyMarkup: inlineKeyboard);
        }

        private async Task HandleShowSessionDetails(ITelegramBotClient botClient, Message message, UserState userState, SessionDetailsDto session)
        {
            var seatsInfo = string.Join("\n", session.available_rows.Select(seat =>
                $"Ряд {seat.row_number}: {string.Join(", ", seat.available_seats)}"));

            var mes = $"""
                {EmojiHelpers.FILM} *{session.movie_title}*
                {EmojiHelpers.TIME} Время: {session.session_start_time:dd.MM.yyyy HH:mm}
                {EmojiHelpers.MONEY} Цена: {session.price} руб.
                {EmojiHelpers.DESCRIPTION} Описание: {session.movie_description}
    
                Доступные места:
                {seatsInfo}
                """;

            await botClient.SendTextMessageAsync(
                message.Chat.Id,
                mes,
                parseMode: ParseMode.Markdown);

            await botClient.SendTextMessageAsync(
                message.Chat.Id,
                "Напишите места, которые хотите купить через пробел в виде: ряд-место. Например, 2 ряд 5 место и 2 ряд 6 место, соответственно: 2-5 2-6",
                replyMarkup: GetKeyboardForState(userState.current_state));
        }

        private async Task HandleSelectSeat(ITelegramBotClient botClient, Message message, UserState userState)
        {
            string[] string_tickets = message.Text.Split(" ");

            var tickets = new List<SelectTicketsDto>();

            foreach (var item in string_tickets)
            {
                if (ParseHelper.TryParsePair(item, out SelectTicketsDto ticket)) {
                    tickets.Add(ticket);
                }
            }
        }
    }
}
