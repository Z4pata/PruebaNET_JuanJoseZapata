using System.Text;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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



// -------------- JWT ----------------

var JWT_ISSUER = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? throw new InvalidOperationException("Issuer no encontrado");

var JWT_Key = Environment.GetEnvironmentVariable("JWT_KEY")?? throw new InvalidOperationException("JWT Key no encontrada");

var Key = Encoding.UTF8.GetBytes(JWT_Key);

Console.WriteLine("Jwt Key: " + Key);

// ------------- Jwt Configurations
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
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Key),  // Agrega la firma de la JWT Key codificada
        ValidIssuer = JWT_ISSUER,   // Agrega un issuer valido, seria la URL del despliegue de la app
        ValidateAudience = false,   // Valida una audiencia (en este caso esta en false, osea no valida) normalmente es la URL del front
        RequireExpirationTime = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// ---------------------------------------

// Add services to the container.
// Add Custom services

builder.Services.AddScoped<IRoomsRepository, RoomRepository>();
builder.Services.AddScoped<IRoomInterface, RoomService>();


builder.Services.AddScoped<IRoomTypesRepository, RoomTypesRepository>();
builder.Services.AddScoped<IRoomTypesInterface, RoomTypesService>();


builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IGuestInterface, GuestService>();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingInterface, BookingService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeInterface, EmployeeService>();

builder.Services.AddScoped<IAuth, AuthService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel API", Version = "v1" });

    // Define security scheme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please, enter your JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    // Require authentication for all endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

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
