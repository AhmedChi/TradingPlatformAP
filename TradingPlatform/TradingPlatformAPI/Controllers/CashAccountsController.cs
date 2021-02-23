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
    public class CashAccountsController : ControllerBase
    {
        private readonly TradingPlatformDatabaseContext _context;

        public CashAccountsController(TradingPlatformDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CashAccounts
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashAccounts>>> GetCashAccounts()
        {
            return await _context.CashAccounts.ToListAsync();
        }

        // GET: api/CashAccounts/5
        [EnableCors]
        [HttpGet("{id}")]
        public async Task<ActionResult<CashAccounts>> GetCashAccounts(int id)
        {
            var cashAccounts = await _context.CashAccounts.FindAsync(id);

            if (cashAccounts == null)
            {
                return NotFound();
            }

            return cashAccounts;
        }

        // PUT: api/CashAccounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashAccounts(int id, CashAccounts cashAccounts)
        {
            if (id != cashAccounts.CashAccountId)
            {
                return BadRequest();
            }

            _context.Entry(cashAccounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashAccountsExists(id))
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

        // POST: api/CashAccounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CashAccounts>> PostCashAccounts(CashAccounts cashAccounts)
        {
            _context.CashAccounts.Add(cashAccounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCashAccounts", new { id = cashAccounts.CashAccountId }, cashAccounts);
        }

        // DELETE: api/CashAccounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CashAccounts>> DeleteCashAccounts(int id)
        {
            var cashAccounts = await _context.CashAccounts.FindAsync(id);
            if (cashAccounts == null)
            {
                return NotFound();
            }

            _context.CashAccounts.Remove(cashAccounts);
            await _context.SaveChangesAsync();

            return cashAccounts;
        }

        private bool CashAccountsExists(int id)
        {
            return _context.CashAccounts.Any(e => e.CashAccountId == id);
        }
    }
}
