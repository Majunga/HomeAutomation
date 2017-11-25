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
    [Route("api/Sensor")]
    public class SensorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SensorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sensor
        [HttpGet]
        public IEnumerable<SensorEntity> GetSensors()
        {
            return _context.Sensors;
        }

        // GET: api/Sensor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensorEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sensorEntity = await _context.Sensors.SingleOrDefaultAsync(m => m.Id == id);

            if (sensorEntity == null)
            {
                return NotFound();
            }

            return Ok(sensorEntity);
        }

        // PUT: api/Sensor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorEntity([FromRoute] int id, [FromBody] SensorEntity sensorEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sensorEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(sensorEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorEntityExists(id))
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

        // POST: api/Sensor
        [HttpPost]
        public async Task<IActionResult> PostSensorEntity([FromBody] SensorEntity sensorEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sensors.Add(sensorEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorEntity", new { id = sensorEntity.Id }, sensorEntity);
        }

        // DELETE: api/Sensor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensorEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sensorEntity = await _context.Sensors.SingleOrDefaultAsync(m => m.Id == id);
            if (sensorEntity == null)
            {
                return NotFound();
            }

            _context.Sensors.Remove(sensorEntity);
            await _context.SaveChangesAsync();

            return Ok(sensorEntity);
        }

        private bool SensorEntityExists(int id)
        {
            return _context.Sensors.Any(e => e.Id == id);
        }
    }
}