using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeAutomationServer.Data;
using HomeAutomationServer.Data.Entities;

namespace HomeAutomationServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Location")]
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Location
        [HttpGet]
        public IEnumerable<LocationEntity> GetLocations()
        {
            return _context.Locations;
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locationEntity = await _context.Locations.SingleOrDefaultAsync(m => m.Id == id);

            if (locationEntity == null)
            {
                return NotFound();
            }

            return Ok(locationEntity);
        }

        // PUT: api/Location/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationEntity([FromRoute] int id, [FromBody] LocationEntity locationEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locationEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(locationEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationEntityExists(id))
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

        // POST: api/Location
        [HttpPost]
        public async Task<IActionResult> PostLocationEntity([FromBody] LocationEntity locationEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Locations.Add(locationEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocationEntity", new { id = locationEntity.Id }, locationEntity);
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locationEntity = await _context.Locations.SingleOrDefaultAsync(m => m.Id == id);
            if (locationEntity == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(locationEntity);
            await _context.SaveChangesAsync();

            return Ok(locationEntity);
        }

        private bool LocationEntityExists(int id)
        {
            return _context.Locations.Any(e => e.Id == id);
        }
    }
}