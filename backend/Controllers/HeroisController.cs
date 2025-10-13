using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Superheroes.Api.Data;
using Superheroes.Api.Entities;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroisController : ControllerBase
    {
        private readonly DataContext _context;

        public HeroisController(DataContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Herois>>> GetHerois()
        {
            var herois = await _context.Herois.ToArrayAsync();
            return Ok(herois);
        }
    }
}