using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SS893Tiers.Api.Data;
using SS893Tiers.Api.Models;

namespace SS893Tiers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/Position
        [HttpGet]
        public async Task<IEnumerable<Position>> Get()
            => await _context.Position.ToListAsync();

        // GET: api/Position/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _context.Position.FindAsync(id));

        // POST: api/Position
        [HttpPost]
        public async Task<IActionResult> Post(Position position)
        {
            if (ModelState.IsValid)
            {
                position.PositionId = Guid.NewGuid();
                _context.Position.Add(position);
                await _context.SaveChangesAsync();
                return Ok(position);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Position/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Position position)
        {
            if (ModelState.IsValid || id == position.PositionId)
            {
                var pos = await _context.Position.FindAsync(id);
                if (pos is null) return BadRequest();
                _context.Position.Attach(pos);
                pos.PositionName = position.PositionName;
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Position/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var position = await _context.Position.FindAsync(id);
            if (position is null) return BadRequest("Invalid Position Id");
            _context.Position.Remove(position);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
