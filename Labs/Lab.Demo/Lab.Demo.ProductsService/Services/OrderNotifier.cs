using Azure.Messaging.ServiceBus;
using System.Text.Json;

namespace Lab.Demo.ProductsService.Services;

public class OrderNotifier
{
	private readonly ServiceBusClient _client;
	private readonly ServiceBusSender _sender;

	public OrderNotifier(string connectionString, string queueName)
	{
		_client = new ServiceBusClient(connectionString);
		_sender = _client.CreateSender(queueName);
	}

	public async Task NotifyOrderCreatedAsync(Order order)
	{
		var messageBody = JsonSerializer.Serialize(new
		{
			order.Id,
			order.CustomerEmail,
			order.TotalAmount
		});

		var message = new ServiceBusMessage(messageBody);
		await _sender.SendMessageAsync(message);
	}
}

public record Order(int Id, string CustomerEmail, decimal TotalAmount);

