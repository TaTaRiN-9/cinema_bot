using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace tg_bot
{
    internal class BotEngine
    {
        private readonly ITelegramBotClient _botClient;
        public BotEngine(ITelegramBotClient botClient)
        {
            _botClient = botClient;
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
            try
            {
                switch (update.Type)
                {
                    case UpdateType.Message:
                        {
                            var message = update.Message;

                            Console.WriteLine($"{message?.From?.Username} ({message?.From?.Id}) написал сообщение: {message?.Text} {message.Chat.Id}");

                            if (message?.Text == "/start")
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
                            } else 
                            {
                                await botClient.SendTextMessageAsync(
                                    chatId: message.Chat.Id,
                                    text: "Что-то пошло не так :(");
                                return;
                            }
                        }
                    case UpdateType.CallbackQuery:
                        {
                            var callbackQuery = update.CallbackQuery;
                            var chat = callbackQuery.Message.Chat;

                            if (callbackQuery.Data == "register")
                            {
                                // необходимо для того чтобы бот понимал, на какую кнопку мы нажали
                                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);

                                await botClient.SendTextMessageAsync(
                                    chat.Id,
                                    "Тут должна быть отправка данных на другой сервис");
                                return;
                            } else if (callbackQuery.Data == "help")
                            {
                                // необходимо для того чтобы бот понимал, на какую кнопку мы нажали
                                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);

                                await botClient.SendTextMessageAsync(
                                    chat.Id,
                                    text: "Этот бот предназначен для покупки билетов в кинотеатр \"Смотрилка\".");
                                return;
                            }
                            return;
                        }
                }
                
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
