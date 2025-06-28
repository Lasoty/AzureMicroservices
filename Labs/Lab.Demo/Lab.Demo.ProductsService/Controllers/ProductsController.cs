using Microsoft.AspNetCore.Mvc;

namespace Lab.Demo.ProductsService.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
	[HttpGet]
	public IActionResult Get() => Ok(new { Source = "ProductService", Products = (string[]) ["Product1", "Product2"] });


	[HttpGet("{id}")]
	public IActionResult Get(int id) => Ok(new { Source = "ProductService", Product = (string)"Product1" });

	[HttpPost]
	public IActionResult Post([FromBody] string product)
	{
		if (string.IsNullOrEmpty(product))
		{
			return BadRequest("Product cannot be null or empty.");
		}
		return CreatedAtAction(nameof(Get), new { id = 1 }, new { Source = "ProductService", Product = product });
	}

	[HttpPut("{id}")]
	public IActionResult Put(int id, [FromBody] string product)
	{
		if (string.IsNullOrEmpty(product))
		{
			return BadRequest("Product cannot be null or empty.");
		}
		return Ok(new { Source = "ProductService", Product = product });
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
		if (id <= 0)
		{
			return BadRequest("Invalid product ID.");
		}
		return NoContent();
	}
}