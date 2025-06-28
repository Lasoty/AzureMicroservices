using Microsoft.AspNetCore.Mvc;

namespace Lab.Demo.ProductsService.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{

	[HttpGet]
	[EndpointSummary("Zwraca listę produktów")]
	public IActionResult Get() => Ok(new { Source = "ProductService", Products = (string[]) ["Product1", "Product2"] });
}