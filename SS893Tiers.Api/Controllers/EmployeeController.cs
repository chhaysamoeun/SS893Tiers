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
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emplolyee>>> GetEmployee()
        {
          if (_context.Employee == null)
          {
              return NotFound();
          }
            return await _context.Employee.Include("Position").Include("Department").ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emplolyee>> GetEmplolyee(Guid id)
        {
          if (_context.Employee == null)
          {
              return NotFound();
          }
            var emplolyee = await _context.Employee.FindAsync(id);

            if (emplolyee == null)
            {
                return NotFound();
            }

            return emplolyee;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmplolyee(Guid id, Emplolyee emplolyee)
        {
            if (id != emplolyee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(emplolyee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmplolyeeExists(id))
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

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emplolyee>> PostEmplolyee(Emplolyee emplolyee)
        {
            if (ModelState.IsValid)
            {
                emplolyee.EmployeeId = Guid.NewGuid();
                _context.Employee.Add(emplolyee);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEmplolyee", new { id = emplolyee.EmployeeId }, emplolyee);
            }
            return BadRequest();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmplolyee(Guid id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var emplolyee = await _context.Employee.FindAsync(id);
            if (emplolyee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(emplolyee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmplolyeeExists(Guid id)
        {
            return (_context.Employee?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
