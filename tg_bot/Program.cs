using tg_bot;
using Telegram.Bot;
using System.Configuration;

string? token = ConfigurationManager.AppSettings["token"];

var botClient = new TelegramBotClient(token);

// Create a new bot instance
var metBot = new BotEngine(botClient);

// Listen for messages sent to the bot
await metBot.ListenForMessagesAsync();