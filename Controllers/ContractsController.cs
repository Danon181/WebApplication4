using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ContractsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Contracts
                .Include(c => c.Client)
                .Include(c => c.Agent)
                .Include(c => c.InsuranceType)
                .Include(c => c.Branch)
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _db.Contracts.FindAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contract item)
        {
            _db.Contracts.Add(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Contracts.FindAsync(id);
            if (item is null) return NotFound();
            _db.Contracts.Remove(item);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}