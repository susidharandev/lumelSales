using lumelSales.Data;
using lumelSales.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string connectionString = "Data Source=Sales.db";
builder.Services.AddDbContext<AppDbContext> (option => option.UseSqlite(connectionString));

builder.Services.AddScoped<CsvImportService>();
builder.Services.AddScoped<SalesAnalysisService>();
builder.Services.AddHostedService<SyncBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
