using System.Reflection;
using HockeyGame.Application.Handlers.CommandHandlers;
using HockeyGame.Core.Repositories;
using HockeyGame.Infrastructure.Data;
using HockeyGame.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<HockeyGameContext>(options => options.UseInMemoryDatabase(databaseName: "HockeyGame"));

builder.Services.AddAutoMapper(typeof(CreatePlayerHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreatePlayerHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Hockey Game API",
        Description = "API permettant de gérer les équipes de Hockey de Montréal, au fils des années.",
        Contact = new OpenApiContact
        {
            Name = "Vincent Tixier",
            Email = "vtixier1@icloud.com",
            Url = new Uri("https://www.linkedin.com/in/vincent-tixier-415916135/"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under gpl-3.0",
            Url = new Uri("https://www.gnu.org/licenses/gpl-3.0.html"),
        }
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();



app.Run();
