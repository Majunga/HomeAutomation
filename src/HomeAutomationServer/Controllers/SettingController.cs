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
    [Route("api/Setting")]
    public class SettingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SettingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Setting
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SettingEntity>), 200)]
        public IEnumerable<SettingEntity> GetSettings()
        {
            return _context.Settings;
        }

        // GET: api/Setting/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SettingEntity), 200)]
        public async Task<IActionResult> GetSettingEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var settingEntity = await _context.Settings.SingleOrDefaultAsync(m => m.Id == id);

            if (settingEntity == null)
            {
                return NotFound();
            }

            return Ok(settingEntity);
        }

        // PUT: api/Setting/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutSettingEntity([FromRoute] int id, [FromBody] SettingEntity settingEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != settingEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(settingEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SettingEntityExists(id))
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

        // POST: api/Setting
        [HttpPost]
        [ProducesResponseType(typeof(SettingEntity), 201)]
        public async Task<IActionResult> PostSettingEntity([FromBody] SettingEntity settingEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Settings.Add(settingEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSettingEntity", new { id = settingEntity.Id }, settingEntity);
        }

        // DELETE: api/Setting/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteSettingEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var settingEntity = await _context.Settings.SingleOrDefaultAsync(m => m.Id == id);
            if (settingEntity == null)
            {
                return NotFound();
            }

            _context.Settings.Remove(settingEntity);
            await _context.SaveChangesAsync();

            return Ok(settingEntity);
        }

        private bool SettingEntityExists(int id)
        {
            return _context.Settings.Any(e => e.Id == id);
        }
    }
}