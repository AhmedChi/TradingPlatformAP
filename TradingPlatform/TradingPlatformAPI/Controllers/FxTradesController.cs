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
    public class FxTradesController : ControllerBase
    {
        private readonly TradingPlatformDatabaseContext _context;
        private readonly IFXTradesControllerService _controllerService;

        public FxTradesController(TradingPlatformDatabaseContext context,
            IFXTradesControllerService controllerService)
        {
            _context = context;
            _controllerService = controllerService;
        }

        // GET: api/FxTrades
        [EnableCors]
        [HttpGet("GetFxTrades")]
        public async Task<ActionResult<IEnumerable<FxTrades>>> GetFxTrades()
        {
            return await _context.FxTrades.ToListAsync();
        }

        [EnableCors]
        [HttpGet("GetFilteredFxTrades")]
        public async Task<ActionResult<IEnumerable<FXTradesModel>>> GetFilteredFxTrades()
        {
            var ListOfAllFxTrades = await _context.FxTrades.ToListAsync();

            return _controllerService.Filter(ListOfAllFxTrades);
        }

        // GET: api/FxTrades/5
        [EnableCors]
        [HttpGet("{id}")]
        public async Task<ActionResult<FxTrades>> GetFxTrades(int id)
        {
            var fxTrades = await _context.FxTrades.FindAsync(id);

            if (fxTrades == null)
            {
                return NotFound();
            }

            return fxTrades;
        }

        // PUT: api/FxTrades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFxTrades(int id, FxTrades fxTrades)
        {
            if (id != fxTrades.FxTradeId)
            {
                return BadRequest();
            }

            _context.Entry(fxTrades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FxTradesExists(id))
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

        // POST: api/FxTrades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FxTrades>> PostFxTrades(FxTrades fxTrades)
        {
            _context.FxTrades.Add(fxTrades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFxTrades", new { id = fxTrades.FxTradeId }, fxTrades);
        }

        // DELETE: api/FxTrades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FxTrades>> DeleteFxTrades(int id)
        {
            var fxTrades = await _context.FxTrades.FindAsync(id);
            if (fxTrades == null)
            {
                return NotFound();
            }

            _context.FxTrades.Remove(fxTrades);
            await _context.SaveChangesAsync();

            return fxTrades;
        }

        private bool FxTradesExists(int id)
        {
            return _context.FxTrades.Any(e => e.FxTradeId == id);
        }
    }
}
