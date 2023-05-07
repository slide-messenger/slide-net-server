using Server.SQLServer;
using System.Reflection.PortableExecutable;

SQLServer.Connect("localhost:5432", "postgres", "DP1u4Fo5OA90hfcvRq2K", "postgres");

Console.WriteLine("SQL Server is running...");

Console.WriteLine("Start HTTP server...");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();


