using API.FurnitureStore.Data;
using API.FurnitureStore.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.FurnitureStore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoryController : ControllerBase
{
    private readonly APIFurnitureStoreContext _context;

    public ProductCategoryController(APIFurnitureStoreContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductCategory>>> Get()
    {
        return await _context.ProductCategories.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var productId = await _context.ProductCategories
            .FirstOrDefaultAsync(x => x.Id == id);

        if (productId == null) return NotFound();

        return Ok(productId);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(ProductCategory productCategory)
    {
        await _context.ProductCategories.AddAsync(productCategory);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("Post", productCategory.Id, productCategory);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(ProductCategory productCategory)
    {
        _context.ProductCategories.Update(productCategory);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ProductCategory productCategory)
    {
        var productId = await _context.ProductCategories
            .FirstOrDefaultAsync(x => x.Id == id);

        if (productId == null) return NotFound();
        
        _context.ProductCategories.Update(productCategory);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(ProductCategory productCategory)
    {
        _context.ProductCategories.Remove(productCategory);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {                
        var productId = await _context.ProductCategories
            .FirstOrDefaultAsync(x => x.Id == id);

        if (productId == null) return NotFound();
        
        _context.ProductCategories.Remove(productId);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}