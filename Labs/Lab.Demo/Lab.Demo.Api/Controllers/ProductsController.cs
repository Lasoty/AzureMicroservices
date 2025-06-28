using Microsoft.AspNetCore.Mvc;

namespace Lab.Demo.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
	[HttpGet]
	public IActionResult Get() => Ok(new { Source = "Monolith", Products = (string[]) ["Product1", "Product2"] });
}