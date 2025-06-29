using Azure.Messaging.ServiceBus;
using System.Text.Json;

namespace Lab.Demo.MailNotificationService;

public class OrderCreatedProcessor
{
	private readonly ServiceBusClient _client;
	private readonly ServiceBusProcessor _processor;

	public OrderCreatedProcessor(string connectionString, string queueName, string subscription = null)
	{
		_client = new ServiceBusClient(connectionString);

		_processor = string.IsNullOrEmpty(subscription) 
			? _client.CreateProcessor(queueName, new ServiceBusProcessorOptions()) 
			: _client.CreateProcessor(queueName, subscription);
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
		Console.WriteLine($"Odebrano: {body}");
		Console.WriteLine($"CorrelationId: {args.Message.ApplicationProperties["CorrelationId"]}");
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

