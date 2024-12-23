using cinema.Data;
using cinema.Data.Repository;
using cinema.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using cinema.Helpers;
using System.Text.Json.Serialization;
using cinema.Abstractions.Tickets;
using cinema.Abstractions.Sessions;
using cinema.Abstractions.Users;
using cinema.Abstractions.Seats;
using cinema.Abstractions.Helpers;
using cinema.Abstractions.Movies;
using cinema.Abstractions.Halls;
using cinema.Abstractions.Rows;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "Cinema API", 
        Version = "v1",
        Description = "An ASP.NET Core Web API дл€ управлени€ системой покупки билетов в кинотеатр",
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddCors();

var authOptions = builder.Configuration.GetSection("Jwt").Get<AuthOptions>();
builder.Services.AddSingleton(authOptions);

builder.Services.AddAuthorization();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = authOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = authOptions.AUDIENCE,
            // будет ли валидироватьс€ врем€ существовани€
            ValidateLifetime = true,
            // валидаци€ ключа безопасности
            ValidateIssuerSigningKey = true,
            // Ѕерем ключ из json и передаем в параметры, то есть устанавливаем его
            IssuerSigningKey = authOptions.GetSymmetricSecurityKey()
        };
    }
);

builder.Services.AddDbContext<CinemaDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("db_conn"));
    });

// DI
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketServices, TicketServices>();

builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ISessionServices, SessionServices>();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieServices, MovieServices>();

builder.Services.AddScoped<IHallServices, HallServices>();
builder.Services.AddScoped<IHallRepository, HallRepository>();

builder.Services.AddScoped<IRowRepository, RowRepository>();

builder.Services.AddScoped<ISeatRepository, SeatRepository>();

builder.Services.AddScoped<IJwtServices, JwtServices>();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
