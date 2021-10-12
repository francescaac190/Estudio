using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estudio.Data;
using Estudio.Models;

namespace Estudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIMusicsController : ControllerBase
    {
        private readonly EstudioDbContext _context;

        public APIMusicsController(EstudioDbContext context)
        {
            _context = context;
        }

        // GET: api/APIMusics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Music>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET: api/APIMusics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Music>> GetMusic(int id)
        {
            var music = await _context.Songs.FindAsync(id);

            if (music == null)
            {
                return NotFound();
            }

            return music;
        }

        // PUT: api/APIMusics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusic(int id, Music music)
        {
            if (id != music.MusicId)
            {
                return BadRequest();
            }

            _context.Entry(music).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(id))
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

        // POST: api/APIMusics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Music>> PostMusic(Music music)
        {
            _context.Songs.Add(music);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusic", new { id = music.MusicId }, music);
        }

        // DELETE: api/APIMusics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var music = await _context.Songs.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(music);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicExists(int id)
        {
            return _context.Songs.Any(e => e.MusicId == id);
        }
    }
}
