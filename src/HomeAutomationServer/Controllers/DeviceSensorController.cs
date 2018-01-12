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
    [Route("api/DeviceSensor")]
    public class DeviceSensorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceSensorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DeviceSensorEntities
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DeviceSensorEntity>), 200)]
        public IEnumerable<DeviceSensorEntity> GetDeviceSensors()
        {
            return _context.DeviceSensors;
        }

        // GET: api/DeviceSensorEntities/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DeviceEntity), 200)]
        public async Task<IActionResult> GetDeviceSensorEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceSensorEntity = await _context.DeviceSensors.SingleOrDefaultAsync(m => m.Id == id);

            if (deviceSensorEntity == null)
            {
                return NotFound();
            }

            return Ok(deviceSensorEntity);
        }

        // PUT: api/DeviceSensorEntities/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutDeviceSensorEntity([FromRoute] int id, [FromBody] DeviceSensorEntity deviceSensorEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceSensorEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(deviceSensorEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceSensorEntityExists(id))
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

        // POST: api/DeviceSensorEntities
        [HttpPost]
        [ProducesResponseType(typeof(DeviceEntity), 201)]
        public async Task<IActionResult> PostDeviceSensorEntity([FromBody] DeviceSensorEntity deviceSensorEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeviceSensors.Add(deviceSensorEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeviceSensorEntity", new { id = deviceSensorEntity.Id }, deviceSensorEntity);
        }

        // DELETE: api/DeviceSensorEntities/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteDeviceSensorEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceSensorEntity = await _context.DeviceSensors.SingleOrDefaultAsync(m => m.Id == id);
            if (deviceSensorEntity == null)
            {
                return NotFound();
            }

            _context.DeviceSensors.Remove(deviceSensorEntity);
            await _context.SaveChangesAsync();

            return Ok(deviceSensorEntity);
        }

        private bool DeviceSensorEntityExists(int id)
        {
            return _context.DeviceSensors.Any(e => e.Id == id);
        }
    }
}