using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Banshee.Models;

namespace Banshee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesRepresentativesController : ControllerBase
    {
        private readonly BansheeContext _context;

        public SalesRepresentativesController(BansheeContext context)
        {
            _context = context;
        }

        // GET: api/SalesRepresentatives
        [HttpGet]
        public IEnumerable<SalesRepresentative> GetSalesRepresentative()
        {
            return _context.SalesRepresentative;
        }

        // GET: api/SalesRepresentatives/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalesRepresentative([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salesRepresentative = await _context.SalesRepresentative.FindAsync(id);

            if (salesRepresentative == null)
            {
                return NotFound();
            }

            return Ok(salesRepresentative);
        }

        // PUT: api/SalesRepresentatives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesRepresentative([FromRoute] int id, [FromBody] SalesRepresentative salesRepresentative)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesRepresentative.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesRepresentative).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesRepresentativeExists(id))
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

        // POST: api/SalesRepresentatives
        [HttpPost]
        public async Task<IActionResult> PostSalesRepresentative([FromBody] SalesRepresentative salesRepresentative)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SalesRepresentative.Add(salesRepresentative);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesRepresentative", new { id = salesRepresentative.Id }, salesRepresentative);
        }

        // DELETE: api/SalesRepresentatives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesRepresentative([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salesRepresentative = await _context.SalesRepresentative.FindAsync(id);
            if (salesRepresentative == null)
            {
                return NotFound();
            }

            _context.SalesRepresentative.Remove(salesRepresentative);
            await _context.SaveChangesAsync();

            return Ok(salesRepresentative);
        }

        private bool SalesRepresentativeExists(int id)
        {
            return _context.SalesRepresentative.Any(e => e.Id == id);
        }
    }
}