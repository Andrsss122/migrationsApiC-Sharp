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
    public class ArtistaController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ArtistaController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Artista
        [HttpGet("{GetAll}")]
        public async Task<ActionResult<IEnumerable<Artista>>> Getartista()
        {
            return await _context.artista.ToListAsync();
        }

        // GET: api/Artista/5
        [HttpGet("{GetById}")]
        public async Task<ActionResult<Artista>> GetArtista(int id)
        {
            var artista = await _context.artista.FindAsync(id);

            if (artista == null)
            {
                return NotFound();
            }

            return artista;
        }

        // PUT: api/Artista/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{Update}")]
        public async Task<IActionResult> PutArtista(int id, Artista artista)
        {
            if (id != artista.IdArtista)
            {
                return BadRequest();
            }

            _context.Entry(artista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistaExists(id))
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

        // POST: api/Artista
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{Create}")]
        public async Task<ActionResult<Artista>> PostArtista(Artista artista)
        {
            _context.artista.Add(artista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtista", new { id = artista.IdArtista }, artista);
        }

        // DELETE: api/Artista/5
        [HttpDelete("{Delete}")]
        public async Task<ActionResult<Artista>> DeleteArtista(int id)
        {
            var artista = await _context.artista.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }

            _context.artista.Remove(artista);
            await _context.SaveChangesAsync();

            return artista;
        }

        private bool ArtistaExists(int id)
        {
            return _context.artista.Any(e => e.IdArtista == id);
        }
    }
}
