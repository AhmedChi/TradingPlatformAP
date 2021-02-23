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
    public class SectorsController : ControllerBase
    {
        private readonly TradingPlatformDatabaseContext _context;

        public SectorsController(TradingPlatformDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Sectors
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sectors>>> GetSectors()
        {
            return await _context.Sectors.ToListAsync();
        }

        // GET: api/Sectors/5
        [EnableCors]
        [HttpGet("{id}")]
        public async Task<ActionResult<Sectors>> GetSectors(int id)
        {
            var sectors = await _context.Sectors.FindAsync(id);

            if (sectors == null)
            {
                return NotFound();
            }

            return sectors;
        }

        // PUT: api/Sectors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSectors(int id, Sectors sectors)
        {
            if (id != sectors.SectorId)
            {
                return BadRequest();
            }

            _context.Entry(sectors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectorsExists(id))
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

        // POST: api/Sectors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sectors>> PostSectors(Sectors sectors)
        {
            _context.Sectors.Add(sectors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSectors", new { id = sectors.SectorId }, sectors);
        }

        // DELETE: api/Sectors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sectors>> DeleteSectors(int id)
        {
            var sectors = await _context.Sectors.FindAsync(id);
            if (sectors == null)
            {
                return NotFound();
            }

            _context.Sectors.Remove(sectors);
            await _context.SaveChangesAsync();

            return sectors;
        }

        private bool SectorsExists(int id)
        {
            return _context.Sectors.Any(e => e.SectorId == id);
        }
    }
}
