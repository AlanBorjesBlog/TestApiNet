using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MascotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var listMascotas = await _context.Mascotas.ToListAsync();
            if (listMascotas == null || listMascotas.Count == 0)
            {
                return NoContent();
            }
            return Ok(listMascotas);
        }

        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            return Ok(mascota);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Mascota mascota)
        {
            if (mascota == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(mascota);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}