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
    [Route("api/Device")]
    public class DeviceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Device
        [HttpGet]
        public IEnumerable<DeviceEntity> GetDevices()
        {
            return _context.Devices;
        }

        // GET: api/Device/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceEntity = await _context.Devices.SingleOrDefaultAsync(m => m.Id == id);

            if (deviceEntity == null)
            {
                return NotFound();
            }

            return Ok(deviceEntity);
        }

        // PUT: api/Device/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceEntity([FromRoute] int id, [FromBody] DeviceEntity deviceEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(deviceEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceEntityExists(id))
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

        // POST: api/Device
        [HttpPost]
        public async Task<IActionResult> PostDeviceEntity([FromBody] DeviceEntity deviceEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Devices.Add(deviceEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeviceEntity", new { id = deviceEntity.Id }, deviceEntity);
        }

        // DELETE: api/Device/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceEntity = await _context.Devices.SingleOrDefaultAsync(m => m.Id == id);
            if (deviceEntity == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(deviceEntity);
            await _context.SaveChangesAsync();

            return Ok(deviceEntity);
        }

        private bool DeviceEntityExists(int id)
        {
            return _context.Devices.Any(e => e.Id == id);
        }
    }
}