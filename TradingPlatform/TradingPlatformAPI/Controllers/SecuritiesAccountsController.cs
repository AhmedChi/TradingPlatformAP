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
    public class SecuritiesAccountsController : ControllerBase
    {
        private readonly TradingPlatformDatabaseContext _context;

        public SecuritiesAccountsController(TradingPlatformDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SecuritiesAccounts
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SecuritiesAccounts>>> GetSecuritiesAccounts()
        {
            return await _context.SecuritiesAccounts.ToListAsync();
        }

        // GET: api/SecuritiesAccounts/5
        [EnableCors]
        [HttpGet("{id}")]
        public async Task<ActionResult<SecuritiesAccounts>> GetSecuritiesAccounts(int id)
        {
            var securitiesAccounts = await _context.SecuritiesAccounts.FindAsync(id);

            if (securitiesAccounts == null)
            {
                return NotFound();
            }

            return securitiesAccounts;
        }

        // PUT: api/SecuritiesAccounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecuritiesAccounts(int id, SecuritiesAccounts securitiesAccounts)
        {
            if (id != securitiesAccounts.SecurityAccountId)
            {
                return BadRequest();
            }

            _context.Entry(securitiesAccounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecuritiesAccountsExists(id))
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

        // POST: api/SecuritiesAccounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SecuritiesAccounts>> PostSecuritiesAccounts(SecuritiesAccounts securitiesAccounts)
        {
            _context.SecuritiesAccounts.Add(securitiesAccounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecuritiesAccounts", new { id = securitiesAccounts.SecurityAccountId }, securitiesAccounts);
        }

        // DELETE: api/SecuritiesAccounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SecuritiesAccounts>> DeleteSecuritiesAccounts(int id)
        {
            var securitiesAccounts = await _context.SecuritiesAccounts.FindAsync(id);
            if (securitiesAccounts == null)
            {
                return NotFound();
            }

            _context.SecuritiesAccounts.Remove(securitiesAccounts);
            await _context.SaveChangesAsync();

            return securitiesAccounts;
        }

        private bool SecuritiesAccountsExists(int id)
        {
            return _context.SecuritiesAccounts.Any(e => e.SecurityAccountId == id);
        }
    }
}
