using API.FurnitureStore.Data;
using API.FurnitureStore.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.FurnitureStore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly APIFurnitureStoreContext _context;

    public ProductController(APIFurnitureStoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _context.Products.ToListAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var productId = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productId == null) return NoContent();

        return Ok(productId);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Post", product.Id, product);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutById(int id, Product product)
    {
        var productId = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productId == null) return NotFound();

        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}