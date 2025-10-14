using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Superheroes.Api.Data;
using Superheroes.Api.Entities;

namespace Superheroes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpoderesController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperpoderesController(DataContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Superpoderes>>> GetSuperpoderes()
        {
            var superpoderes = await _context.Superpoderes.ToListAsync();
            return Ok(superpoderes);
        }
    }    

}


