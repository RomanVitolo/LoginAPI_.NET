﻿using API.FurnitureStore.Data;
using API.FurnitureStore.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.FurnitureStore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly APIFurnitureStoreContext _context;

    public ClientController(APIFurnitureStoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Client>> Get()
    {
       return await _context.Clients.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetails(int id)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

        if (client == null) return NotFound();

        return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Post", client.Id, client);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Client client)
    {
        _context.Clients.Update(client);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete]

    public async Task<IActionResult> Delete(Client client)
    {
        if (client == null) return NotFound();

         _context.Clients.Remove(client);

         await _context.SaveChangesAsync();

         return NoContent();
    }
    
}