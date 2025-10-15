using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs;
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
            var heroisDto = await _context.Herois.Include(h => h.Superpoderes).Select(h => new HeroiDTOSaida
            {
                Id = h.Id,
                Nome = h.Nome,
                NomeHeroi = h.NomeHeroi,
                Altura = h.Altura,
                Peso = h.Peso,
                DataNascimento = h.DataNascimento,
                Superpoderes = h.Superpoderes.Select(sp => new SuperpoderDTO
                {
                    Id = sp.Id,
                    Superpoder = sp.Superpoder
                }).ToList()
            }).ToListAsync();

            if (!heroisDto.Any())
            {
                return NotFound("Nenhum herói foi encontrado.");
            }

            return Ok(heroisDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HeroiDTOSaida>> GetHeroiPorID(int id)
        {
            var heroi = await _context.Herois.Include(h => h.Superpoderes).FirstOrDefaultAsync(h => h.Id == id);

            if (heroi == null)
            {
                return NotFound();
            }

            var heroiRespostaDto = new HeroiDTOSaida
            {
                Id = heroi.Id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
                DataNascimento = heroi.DataNascimento,
                Superpoderes = heroi.Superpoderes.Select(sp => new SuperpoderDTO
                {
                    Id = sp.Id,
                    Superpoder = sp.Superpoder
                }).ToList()
            };

            return Ok(heroiRespostaDto);
        }

        [HttpPost]
        public async Task<ActionResult<Herois>> Criarheroi(HeroiDTOCriacao heroiDto)
        {
            var heroi = new Herois
            { // Mapeando as propriedades do DTO para o tipo "Herois"
                Nome = heroiDto.Nome,
                NomeHeroi = heroiDto.NomeHeroi,
                DataNascimento = heroiDto.DataNascimento,
                Altura = heroiDto.Altura,
                Peso = heroiDto.Peso,
                Superpoderes = new List<Superpoderes>()
            };

            //Lógica para lidar com os IDs de superpoderes vindos do DTO
            foreach (var superpoderId in heroiDto.SuperpoderesIds)
            {
                var superpoderesDoBanco = await _context.Superpoderes.FindAsync(superpoderId);
                if (superpoderesDoBanco != null)
                {
                    heroi.Superpoderes.Add(superpoderesDoBanco);
                }
            }

            _context.Herois.Add(heroi);
            await _context.SaveChangesAsync();

            var heroiRespostaDto = new HeroiDTOSaida
            {
                Id = heroi.Id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
                DataNascimento = heroi.DataNascimento,
                Superpoderes = heroi.Superpoderes.Select(p => new SuperpoderDTO
                {
                    Id = p.Id,
                    Superpoder = p.Superpoder
                }).ToList()
            };

            return CreatedAtAction("GetHeroiPorID", new { id = heroiRespostaDto.Id }, heroiRespostaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarHeroi(int id, [FromBody] HeroiDTOCriacao heroiDto)
        {
            var heroiBd = await _context.Herois.Include(h => h.Superpoderes).FirstOrDefaultAsync(h => h.Id == id);

            if (heroiBd == null)
            {
                return NotFound();
            }

            var nomeEmUso = await _context.Herois.AnyAsync(h => h.NomeHeroi == heroiDto.NomeHeroi && h.Id != id);
            if (nomeEmUso)
            {
                return Conflict("Já existe outro herói com este nome de herói.");
            }

            heroiBd.Nome = heroiDto.Nome;
            heroiBd.NomeHeroi = heroiDto.NomeHeroi;
            heroiBd.DataNascimento = heroiDto.DataNascimento;
            heroiBd.Altura = heroiDto.Altura;
            heroiBd.Peso = heroiDto.Peso;

            heroiBd.Superpoderes.Clear();
            foreach (var poderId in heroiDto.SuperpoderesIds)
            {
                var superpoderBd = await _context.Superpoderes.FindAsync(poderId);
                if (superpoderBd != null)
                {
                    heroiBd.Superpoderes.Add(superpoderBd);
                }
            }

            await _context.SaveChangesAsync();

            var heroiRespostaDto = new HeroiDTOSaida
            {
                Id = heroiBd.Id,
                Nome = heroiBd.Nome,
                NomeHeroi = heroiBd.NomeHeroi,
                Altura = heroiBd.Altura,
                Peso = heroiBd.Peso,
                DataNascimento = heroiBd.DataNascimento,
                Superpoderes = heroiBd.Superpoderes.Select(sp => new SuperpoderDTO
                {
                    Id = sp.Id,
                    Superpoder = sp.Superpoder
                }).ToList()
            };

            return Ok(heroiRespostaDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ApagarHeroiPorId(int id)
        {
            var heroiBd = await _context.Herois.FindAsync(id);

            if (heroiBd == null)
            {
                return NotFound();
            }

            _context.Herois.Remove(heroiBd);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}