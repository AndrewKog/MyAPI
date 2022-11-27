using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic; 
using System.Threading.Tasks;
using MyAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Http;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly DataContext _context;

        public MatchController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Match>>> GetGames()
        {
            return Ok(await _context.Match.Include(w => w.MatchOdds).ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Match>>> CreateMatch(Match match)
        {
            try
            {
                _context.Match.Add(match);
            await _context.SaveChangesAsync();

            return Ok(await _context.Match.ToListAsync());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error inserting data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<Match>>> UpdateMatch(Match match)
        {
            try
            {

                var dbMatch = await _context.Match.Include(p => p.MatchOdds).FirstOrDefaultAsync(p => p.Id == match.Id);

                if (dbMatch == null)
                return BadRequest("Match not found");

            dbMatch.Description = match.Description;
            dbMatch.MatchDate = match.MatchDate;
            dbMatch.MatchTime = match.MatchTime;
            dbMatch.TeamA = match.TeamA;
            dbMatch.TeamB = match.TeamB;
            dbMatch.Sport = match.Sport;

                for (int i = 0; i <= dbMatch.MatchOdds.Count-1; i++)
                {
                    dbMatch.MatchOdds[i].Specifier = match.MatchOdds[i].Specifier;
                    dbMatch.MatchOdds[i].Odd = match.MatchOdds[i].Odd;

                }


                await _context.SaveChangesAsync();

            return Ok(await _context.Match.ToListAsync());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Match>>> DeleteMatch(int id)
        {
            try
            {

                var dbMatch = await _context.Match.Include(p => p.MatchOdds).FirstOrDefaultAsync(p => p.Id == id);


                if (dbMatch == null)
                    return BadRequest("Match not found");

             

                _context.Match.Remove(dbMatch);

                await _context.SaveChangesAsync();

                return Ok(await _context.Match.ToListAsync());

            }
            catch (Exception)
            { 

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }





    }
}
