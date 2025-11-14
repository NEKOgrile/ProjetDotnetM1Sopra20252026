using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetDotnetM1Sopra20252026.Models;

namespace ProjetDotnetM1Sopra20252026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoituresDTOController : ControllerBase
    {
        private readonly BDDContext _context;

        public VoituresDTOController(BDDContext context)
        {
            _context = context;
        }

        //Afficher toutes les voitures
        // GET: api/VoituresDTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoitureDTO>>> GetVoituresDTO()
        {
            return await _context.Voitures.Select(v => v.toDTO()).ToListAsync();
        }

        //Afficher une voiture par son IDparam : (int id)
        // GET: api/VoituresDTO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VoitureDTO>> GetVoitureDTO(int id)
        {
            var voiture = await _context.Voitures.FindAsync(id);

            if (voiture == null)
            {
                return NotFound();
            }

            return voiture.toDTO();
        }

        //Rechercher une voiture param : (string recherche)
        [HttpGet("search/{search}")]
        public async Task<ActionResult<IEnumerable<VoitureDTO>>> Search(string search)
        {
            return await _context.Voitures
                .Where(v => v.Marque.Contains(search) || v.Modele.Contains(search))
                .Select(v => v.toDTO()).ToListAsync();
        }
    }
}
