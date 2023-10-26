using Microsoft.EntityFrameworkCore;
using SampleApp.Api.Extensions;
using SampleApp.Infra.Contexts;
using SampleApp.Shared.Notifications.AspNet;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddNotifications();
builder.Services.AddApplicationServices();
builder.Services.AddDatabaseContext(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MigrateAndSeedData();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/healthz");

app.Run();
