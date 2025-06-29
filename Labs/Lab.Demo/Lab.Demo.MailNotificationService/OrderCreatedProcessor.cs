using Azure.Messaging.ServiceBus;
using System.Text.Json;

namespace Lab.Demo.MailNotificationService;

public class OrderCreatedProcessor
{
	private readonly ServiceBusClient _client;
	private readonly ServiceBusProcessor _processor;

	public OrderCreatedProcessor(string connectionString, string queueName)
	{
		_client = new ServiceBusClient(connectionString);
		_processor = _client.CreateProcessor(queueName, new ServiceBusProcessorOptions());
	}

	public async Task StartProcessingAsync()
	{
		_processor.ProcessMessageAsync += ProcessMessageHandler;
		_processor.ProcessErrorAsync += ErrorHandler;

		await _processor.StartProcessingAsync();
	}

	private async Task ProcessMessageHandler(ProcessMessageEventArgs args)
	{
		var body = args.Message.Body.ToString();
		var orderData = JsonSerializer.Deserialize<OrderCreatedMessage>(body);

		// Wyślij maila
		await SendConfirmationEmail(orderData.CustomerEmail, orderData.Id);

		await args.CompleteMessageAsync(args.Message);
	}

	private Task ErrorHandler(ProcessErrorEventArgs args)
	{
		// Logowanie błędu

		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(args.Exception.Message);
		Console.ResetColor();
		return Task.CompletedTask;
	}

	private Task SendConfirmationEmail(string email, int orderId)
	{
		// Implementacja wysyłki maila
		Console.WriteLine($"Odebrano wiadomość: email: {email}, orderId:{orderId}.");
		return Task.CompletedTask;
	}
}

public record OrderCreatedMessage(int Id, string CustomerEmail, decimal TotalAmount);

