using Microsoft.AspNetCore.Mvc;

namespace Lab.Demo.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
	[HttpGet]
	public IActionResult Get() => Ok(new { Source = "Monolith", Orders = (string[]) ["Order1", "Order2"] });
}