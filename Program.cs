using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PruebaNET_JuanJoseZapata.Data;
using PruebaNET_JuanJoseZapata.Repositories;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;
using PruebaNET_JuanJoseZapata.Service;

var builder = WebApplication.CreateBuilder(args);

// Add Environment variables
Env.Load();

var DB_HOST = Environment.GetEnvironmentVariable("DB_HOST");
var DB_NAME = Environment.GetEnvironmentVariable("DB_NAME");
var DB_PORT = Environment.GetEnvironmentVariable("DB_PORT");
var DB_USER = Environment.GetEnvironmentVariable("DB_USER");
var DB_PASSWORD = Environment.GetEnvironmentVariable("DB_PASSWORD");


// Add connection string
var stringConnection = $"server={DB_HOST};port={DB_PORT};database={DB_NAME};uid={DB_USER};password={DB_PASSWORD}";

// --------- Connect with the DataBase -------------
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseMySql(stringConnection, ServerVersion.Parse("8.0.20-mysql"));
});

// Add services to the container.
// Add Custom services

builder.Services.AddScoped<IRoomsRepository, RoomRepository>();
builder.Services.AddScoped<IRoomInterface, RoomService>();

builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IGuestInterface, GuestService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel Assestment", Version = "v1" });
        
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// Redirect to swagger page
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
