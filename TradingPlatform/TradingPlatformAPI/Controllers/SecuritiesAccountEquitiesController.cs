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
    public class SecuritiesAccountEquitiesController : ControllerBase
    {
        private readonly TradingPlatformDatabaseContext _context;

        public SecuritiesAccountEquitiesController(TradingPlatformDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SecuritiesAccountEquities
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SecuritiesAccountEquities>>> GetSecuritiesAccountEquities()
        {
            return await _context.SecuritiesAccountEquities.ToListAsync();
        }

        // GET: api/SecuritiesAccountEquities/5
        [EnableCors]
        [HttpGet("{id}")]
        public async Task<ActionResult<SecuritiesAccountEquities>> GetSecuritiesAccountEquities(int id)
        {
            var securitiesAccountEquities = await _context.SecuritiesAccountEquities.FindAsync(id);

            if (securitiesAccountEquities == null)
            {
                return NotFound();
            }

            return securitiesAccountEquities;
        }

        // PUT: api/SecuritiesAccountEquities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecuritiesAccountEquities(int id, SecuritiesAccountEquities securitiesAccountEquities)
        {
            if (id != securitiesAccountEquities.SecuritiesAccountEquityId)
            {
                return BadRequest();
            }

            _context.Entry(securitiesAccountEquities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecuritiesAccountEquitiesExists(id))
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

        // POST: api/SecuritiesAccountEquities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SecuritiesAccountEquities>> PostSecuritiesAccountEquities(SecuritiesAccountEquities securitiesAccountEquities)
        {
            _context.SecuritiesAccountEquities.Add(securitiesAccountEquities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecuritiesAccountEquities", new { id = securitiesAccountEquities.SecuritiesAccountEquityId }, securitiesAccountEquities);
        }

        // DELETE: api/SecuritiesAccountEquities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SecuritiesAccountEquities>> DeleteSecuritiesAccountEquities(int id)
        {
            var securitiesAccountEquities = await _context.SecuritiesAccountEquities.FindAsync(id);
            if (securitiesAccountEquities == null)
            {
                return NotFound();
            }

            _context.SecuritiesAccountEquities.Remove(securitiesAccountEquities);
            await _context.SaveChangesAsync();

            return securitiesAccountEquities;
        }

        private bool SecuritiesAccountEquitiesExists(int id)
        {
            return _context.SecuritiesAccountEquities.Any(e => e.SecuritiesAccountEquityId == id);
        }
    }
}
