using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceTypesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public InsuranceTypesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.InsuranceTypes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _db.InsuranceTypes.FindAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsuranceType item)
        {
            _db.InsuranceTypes.Add(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.InsuranceTypes.FindAsync(id);
            if (item is null) return NotFound();

            bool isUsed = _db.Contracts.Any(c => c.InsuranceTypeId == id);
            if (isUsed) return BadRequest("Нельзя удалить: вид страхования используется в договорах");

            _db.InsuranceTypes.Remove(item);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}