using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;
namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public AgentsController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Agents.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _db.Agents.FindAsync(id);
            return item is null ? NotFound() : Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Agent item)
        {
            _db.Agents.Add(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Agents.FindAsync(id);
            if (item is null) return NotFound();
            _db.Agents.Remove(item);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}