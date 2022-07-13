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
    public class AlbumsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public AlbumsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Albums
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Album>>> Getalbum()
        {
            return await _context.album.ToListAsync();
        }

        // GET: api/Albums/5
        [HttpGet("GetById")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.album.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Update")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (id != album.IdAlbum)
            {
                return BadRequest();
            }

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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

        // POST: api/Albums
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Create")]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            _context.album.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = album.IdAlbum }, album);
        }

        // DELETE: api/Albums/5
        [HttpDelete("Delete")]
        public async Task<ActionResult<Album>> DeleteAlbum(int id)
        {
            var album = await _context.album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.album.Remove(album);
            await _context.SaveChangesAsync();

            return album;
        }

        private bool AlbumExists(int id)
        {
            return _context.album.Any(e => e.IdAlbum == id);
        }
    }
}
