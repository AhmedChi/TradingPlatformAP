using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradingPlatformAPI.Models;

namespace TradingPlatformAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquitiesController : ControllerBase
    {
        private readonly TradingPlatformDatabaseContext _context;

        public EquitiesController(TradingPlatformDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Equities
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equities>>> GetEquities()
        {
            return await _context.Equities.ToListAsync();
        }

        // GET: api/Equities/5
        [EnableCors]
        [HttpGet("{id}")]
        public async Task<ActionResult<Equities>> GetEquities(int id)
        {
            var equities = await _context.Equities.FindAsync(id);

            if (equities == null)
            {
                return NotFound();
            }

            return equities;
        }

        // PUT: api/Equities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquities(int id, Equities equities)
        {
            if (id != equities.EquityId)
            {
                return BadRequest();
            }

            _context.Entry(equities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquitiesExists(id))
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

        // POST: api/Equities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Equities>> PostEquities(Equities equities)
        {
            _context.Equities.Add(equities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquities", new { id = equities.EquityId }, equities);
        }

        // DELETE: api/Equities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Equities>> DeleteEquities(int id)
        {
            var equities = await _context.Equities.FindAsync(id);
            if (equities == null)
            {
                return NotFound();
            }

            _context.Equities.Remove(equities);
            await _context.SaveChangesAsync();

            return equities;
        }

        private bool EquitiesExists(int id)
        {
            return _context.Equities.Any(e => e.EquityId == id);
        }
    }
}
