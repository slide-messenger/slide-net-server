using Server.SQLServer;

Console.WriteLine($"Connecting to SQL Server at {SQLServer.host}...");
try
{
    await SQLServer.Connect();
    Console.WriteLine("Connected to SQL Server");
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}

Console.WriteLine("Start HTTP server...");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

return 0;
