using Lab.Demo.ProductsService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Demo.ProductsService.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{

	[HttpGet]
	[EndpointSummary("Zwraca listę produktów")]
	public IActionResult Get() => Ok(new { Source = "ProductService", Products = (string[]) ["Product1", "Product2"] });


	[HttpGet("{id}")]
	[EndpointSummary("Zwraca szczegóły produktu")]
	public IActionResult GetById(int id)
	{
		if (id <= 0)
			return BadRequest("Invalid product ID");
		return Ok(new { Source = "ProductService", Product = $"Product{id}" });
	}

	[HttpPost]
	[EndpointSummary("Tworzy nowy produkt")]
	public async Task<IActionResult> Create([FromBody] string product)
	{
		if (string.IsNullOrWhiteSpace(product))
			return BadRequest("Product name cannot be empty");

		string connectionString = "";
		string queueName = "order-created-queue";
		var notifier = new OrderNotifier(connectionString, queueName);
		await notifier.NotifyOrderCreatedAsync(new(1, "lasoty@o2.pl", 100.01m));

		return CreatedAtAction(nameof(GetById), new { id = 1 }, new { Source = "ProductService", Product = product });
	}

	[HttpPut]
	public async Task<IActionResult> Update()
	{
		string connectionString = "";
		string queueName = "order-events";
		var notifier = new OrderNotifier(connectionString, queueName);
		await notifier.SendEvent(new(1, "lasoty@o2.pl", 100.01m));

		return Ok();
	}

}