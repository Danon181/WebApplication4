using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;
namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ClientsController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Clients.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _db.Clients.FindAsync(id);
            return item is null ? NotFound() : Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Client item)
        {
            _db.Clients.Add(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Clients.FindAsync(id);
            if (item is null) return NotFound();
            _db.Clients.Remove(item);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}