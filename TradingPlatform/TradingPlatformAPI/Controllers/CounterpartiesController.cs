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
    public class CounterpartiesController : ControllerBase
    {
        private readonly TradingPlatformDatabaseContext _context;

        public CounterpartiesController(TradingPlatformDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Counterparties
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Counterparties>>> GetCounterparties()
        {
            return await _context.Counterparties.ToListAsync();
        }

        // GET: api/Counterparties/5
        [EnableCors]
        [HttpGet("{id}")]
        public async Task<ActionResult<Counterparties>> GetCounterparties(int id)
        {
            var counterparties = await _context.Counterparties.FindAsync(id);

            if (counterparties == null)
            {
                return NotFound();
            }

            return counterparties;
        }

        // PUT: api/Counterparties/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCounterparties(int id, Counterparties counterparties)
        {
            if (id != counterparties.CounterpartyId)
            {
                return BadRequest();
            }

            _context.Entry(counterparties).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CounterpartiesExists(id))
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

        // POST: api/Counterparties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Counterparties>> PostCounterparties(Counterparties counterparties)
        {
            _context.Counterparties.Add(counterparties);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCounterparties", new { id = counterparties.CounterpartyId }, counterparties);
        }

        // DELETE: api/Counterparties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Counterparties>> DeleteCounterparties(int id)
        {
            var counterparties = await _context.Counterparties.FindAsync(id);
            if (counterparties == null)
            {
                return NotFound();
            }

            _context.Counterparties.Remove(counterparties);
            await _context.SaveChangesAsync();

            return counterparties;
        }

        private bool CounterpartiesExists(int id)
        {
            return _context.Counterparties.Any(e => e.CounterpartyId == id);
        }
    }
}
