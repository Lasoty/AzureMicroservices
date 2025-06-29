var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int counter = 0;

app.MapGet("/api/faulty-service", () =>
{
	counter++;
	if (counter <= 2)
	{
		Console.WriteLine($"Request {counter}: returning 500");
		return Results.StatusCode(500);
	}
	Console.WriteLine($"Request {counter}: returning 200");
	return Results.Ok(new { Message = "Success" });
});

app.Run();