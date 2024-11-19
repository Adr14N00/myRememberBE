using Microsoft.AspNetCore.Localization;
using MyRemember.Application;
using MyRemember.Infrastructure;
using MyRemember.Persistence;
using Serilog;
using System.Globalization;



var AllowAnyOrigins = "AllowAnyOrigins";
var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var environment = builder.Environment;

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(config)
  .Enrich.FromLogContext()
  .CreateLogger();

// Add Api Layers (clean Arch - Onion)
builder.Services.AddApplication();
builder.Services.AddInfrastructure(config);
builder.Services.AddPersistence(config);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("pl") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
