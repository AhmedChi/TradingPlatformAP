using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradingPlatformAPI.Models;
using TradingPlatformAPI.Repository.ControllerServices;
using TradingPlatformAPI.Repository.dtos;

namespace TradingPlatformAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {
        private readonly TradingPlatformDatabaseContext _context;
        private readonly ITradesControllerService _controllerService;

        public TradesController(TradingPlatformDatabaseContext context,
            ITradesControllerService controllerService)
        {
            _context = context;
            _controllerService = controllerService;
        }

        // GET: api/Trades/GetTrades
        [HttpGet("GetTrades")]
        [EnableCors]
        public async Task<ActionResult<IEnumerable<Trades>>> GetTrades()
        {
            return await _context.Trades.ToListAsync();
        }

        // GET: api/Trades/GetFilteredTrades
        [HttpGet("GetFilteredTrades")]
        [EnableCors]
        public async Task <ActionResult<IEnumerable<TradesModel>>> GetFilteredTrades()
        {
            var ListOfAllTrades = await _context.Trades.ToListAsync();

            return _controllerService.Filter(ListOfAllTrades);
        }

        // GET: api/Trades
        [HttpGet("GetSoldTradesProfitOrLoss")]
        [EnableCors]
        public async Task<ActionResult<IEnumerable<TradesModel>>> GetSoldTradesProfitOrLoss()
        {
            var ListOfAllTrades = await _context.Trades.ToListAsync();

            return _controllerService.Calculate(ListOfAllTrades);
        }

        // GET: api/Trades/5
        [HttpGet("{id}")]
        [EnableCors]
        public async Task<ActionResult<Trades>> GetTrades(int id)
        {
            var trades = await _context.Trades.FindAsync(id);

            if (trades == null)
            {
                return NotFound();
            }

            return trades;
        }

        // PUT: api/Trades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrades(int id, Trades trades)
        {
            if (id != trades.TradeId)
            {
                return BadRequest();
            }

            _context.Entry(trades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradesExists(id))
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

        // POST: api/Trades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Trades>> PostTrades(Trades trades)
        {
            _context.Trades.Add(trades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrades", new { id = trades.TradeId }, trades);
        }

        // DELETE: api/Trades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trades>> DeleteTrades(int id)
        {
            var trades = await _context.Trades.FindAsync(id);
            if (trades == null)
            {
                return NotFound();
            }

            _context.Trades.Remove(trades);
            await _context.SaveChangesAsync();

            return trades;
        }

        private bool TradesExists(int id)
        {
            return _context.Trades.Any(e => e.TradeId == id);
        }
    }
}
