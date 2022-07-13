using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlbumApi.Data;

namespace AlbumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public GeneroController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Genero
        [HttpGet("{GetAll}")]
        public async Task<ActionResult<IEnumerable<Genero>>> Getgenero()
        {
            return await _context.genero.ToListAsync();
        }

        // GET: api/Genero/5
        [HttpGet("{GetById}")]
        public async Task<ActionResult<Genero>> GetGenero(int id)
        {
            var genero = await _context.genero.FindAsync(id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        // PUT: api/Genero/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{Update}")]
        public async Task<IActionResult> PutGenero(int id, Genero genero)
        {
            if (id != genero.IdGenero)
            {
                return BadRequest();
            }

            _context.Entry(genero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Genero
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{Create}")]
        public async Task<ActionResult<Genero>> PostGenero(Genero genero)
        {
            _context.genero.Add(genero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenero", new { id = genero.IdGenero }, genero);
        }

        // DELETE: api/Genero/5
        [HttpDelete("{Delete}")]
        public async Task<ActionResult<Genero>> DeleteGenero(int id)
        {
            var genero = await _context.genero.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            _context.genero.Remove(genero);
            await _context.SaveChangesAsync();

            return genero;
        }

        private bool GeneroExists(int id)
        {
            return _context.genero.Any(e => e.IdGenero == id);
        }
    }
}
