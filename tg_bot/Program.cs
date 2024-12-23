using tg_bot;
using Telegram.Bot;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tg_bot.requests;
using tg_bot.abstractions;

string token = ConfigurationManager.AppSettings["token"] ?? "";
var botClient = new TelegramBotClient(token);

// Чтобы спокойно использовать IHttpClientFactory (не терять сокеты)
var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<ITelegramBotClient>(botClient);

        // Регистрация HttpClientFactory
        services.AddHttpClient<IBookingServices, BookingServices>(client =>
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["base_address"] ?? "");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        services.AddSingleton<IBotEngine, BotEngine>();

        services.AddMemoryCache();
    });

var app = builder.Build();

await app.Services.GetRequiredService<IBotEngine>().ListenForMessagesAsync();