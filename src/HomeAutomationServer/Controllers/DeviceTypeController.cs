using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeAutomationServer.Data;
using DataLayer.Entities;

namespace HomeAutomationServer.Controllers
{
    [Produces("application/json")]
    [Route("api/DeviceType")]
    public class DeviceTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DeviceType
        [HttpGet]
        public IEnumerable<DeviceTypeEntity> GetDeviceTypes()
        {
            return _context.DeviceTypes;
        }

        // GET: api/DeviceType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceTypeEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceTypeEntity = await _context.DeviceTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (deviceTypeEntity == null)
            {
                return NotFound();
            }

            return Ok(deviceTypeEntity);
        }

        // PUT: api/DeviceType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceTypeEntity([FromRoute] int id, [FromBody] DeviceTypeEntity deviceTypeEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceTypeEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(deviceTypeEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceTypeEntityExists(id))
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

        // POST: api/DeviceType
        [HttpPost]
        public async Task<IActionResult> PostDeviceTypeEntity([FromBody] DeviceTypeEntity deviceTypeEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeviceTypes.Add(deviceTypeEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeviceTypeEntity", new { id = deviceTypeEntity.Id }, deviceTypeEntity);
        }

        // DELETE: api/DeviceType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceTypeEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceTypeEntity = await _context.DeviceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (deviceTypeEntity == null)
            {
                return NotFound();
            }

            _context.DeviceTypes.Remove(deviceTypeEntity);
            await _context.SaveChangesAsync();

            return Ok(deviceTypeEntity);
        }

        private bool DeviceTypeEntityExists(int id)
        {
            return _context.DeviceTypes.Any(e => e.Id == id);
        }
    }
}