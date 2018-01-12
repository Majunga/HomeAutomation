using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeAutomationServer.Data.Entities;
using HomeAutomationServer.Data;

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
        [ProducesResponseType(typeof(IEnumerable<DeviceEntity>), 200)]
        public IEnumerable<DeviceEntity> GetDevices()
        {
            return _context.Devices;
        }

        // GET: api/Device/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DeviceEntity), 200)]
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
        [ProducesResponseType(204)]
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

        /// <summary>
        /// Posts Device to server
        /// </summary>
        /// <param name="deviceEntity"></param>
        /// <returns>DeviceEntity</returns>
        [HttpPost]
        [ProducesResponseType(typeof(DeviceEntity), 201)]
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
        [ProducesResponseType(201)]
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

            return Ok();
        }

        private bool DeviceEntityExists(int id)
        {
            return _context.Devices.Any(e => e.Id == id);
        }
    }
}