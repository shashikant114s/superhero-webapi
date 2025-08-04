using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeros.Context;
using SuperHeros.Entities;

namespace SuperHeros.Controllers
{
    [Route("api/SuperHero")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "v2")]
    public class SuperHeroController : ControllerBase
    {
        private readonly RepositoryContext _repositoryContext;
        public SuperHeroController(RepositoryContext repositoryContext) => _repositoryContext = repositoryContext;

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetSuperHeros()
        {
            var heros = await _repositoryContext.SuperHeroes.ToListAsync();
            return Ok(heros);
        }

        [HttpGet("{id}", Name = "GetHero")]
        public async Task<IActionResult> GetSuperHeros(int id)
        {
            if (id < 1)
                return BadRequest($"The Id can't be 0 or negative.");

            var hero = await _repositoryContext.SuperHeroes.FindAsync(id);

            if (hero == null)
                return NotFound($"The SuperHero with Id of {id}, not found in the Database.");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHero(SuperHero hero)
        {
            if (hero == null)
                return BadRequest($"Hero object can't be null.");

            _repositoryContext.SuperHeroes.Add(hero);
            await _repositoryContext.SaveChangesAsync();

            return CreatedAtRoute("GetHero", new { id = hero.Id }, hero);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHero(SuperHero hero)
        {
            if (hero == null)
                return BadRequest($"Hero object can't be null.");

            var dbHero = await _repositoryContext.SuperHeroes.FindAsync(hero.Id);
            if (dbHero == null)
                return NotFound($"The SuperHero with Id of {hero.Id}, not found in the Database.");

            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _repositoryContext.SaveChangesAsync();
            return CreatedAtRoute("GetHero", new { id = dbHero.Id }, dbHero);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var dbHero = await _repositoryContext.SuperHeroes.FindAsync(id);
            if (dbHero == null)
                return NotFound($"The SuperHero with Id of {id}, not found in the Database.");

            _repositoryContext.SuperHeroes.Remove(dbHero);
            await _repositoryContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
