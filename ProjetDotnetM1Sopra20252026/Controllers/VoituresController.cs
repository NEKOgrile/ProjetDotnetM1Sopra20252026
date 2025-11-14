using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetDotnetM1Sopra20252026.Models;

namespace ProjetDotnetM1Sopra20252026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoituresController : ControllerBase
    {
        private readonly BDDContext _context;

        public VoituresController(BDDContext context)
        {
            _context = context;
        }

        // GET: api/Voitures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voiture>>> GetVoitures()
        {
            return await _context.Voitures.ToListAsync();
        }

        // GET: api/Voitures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voiture>> GetVoiture(int id)
        {
            var voiture = await _context.Voitures.FindAsync(id);

            if (voiture == null)
            {
                return NotFound();
            }

            return voiture;
        }

        // PUT: api/Voitures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoiture(int id, Voiture voiture)
        {
            if (id != voiture.Id)
            {
                return BadRequest();
            }

            _context.Entry(voiture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoitureExists(id))
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

        // POST: api/Voitures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voiture>> PostVoiture(Voiture voiture)
        {
            _context.Voitures.Add(voiture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoiture", new { id = voiture.Id }, voiture);
        }

        // DELETE: api/Voitures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoiture(int id)
        {
            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture == null)
            {
                return NotFound();
            }

            _context.Voitures.Remove(voiture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoitureExists(int id)
        {
            return _context.Voitures.Any(e => e.Id == id);
        }
    }
}
