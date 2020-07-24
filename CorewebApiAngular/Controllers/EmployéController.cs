using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CorewebApiAngular.Models;

namespace CorewebApiAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployéController : ControllerBase
    {
        private readonly PayementDetailContext _context;

        public EmployéController(PayementDetailContext context)
        {
            _context = context;
        }

        // GET: api/Employé
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employé>>> GetEmployé()
        {
            return await _context.Employé.ToListAsync();
        }

        // GET: api/Employé/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employé>> GetEmployé(int id)
        {
            var employé = await _context.Employé.FindAsync(id);

            if (employé == null)
            {
                return NotFound();
            }

            return employé;
        }

        // PUT: api/Employé/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployé(int id, Employé employé)
        {
            if (id != employé.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employé).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployéExists(id))
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

        // POST: api/Employé
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employé>> PostEmployé(Employé employé)
        {
            _context.Employé.Add(employé);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployé", new { id = employé.EmpId }, employé);
        }

        // DELETE: api/Employé/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employé>> DeleteEmployé(int id)
        {
            var employé = await _context.Employé.FindAsync(id);
            if (employé == null)
            {
                return NotFound();
            }

            _context.Employé.Remove(employé);
            await _context.SaveChangesAsync();

            return employé;
        }

        private bool EmployéExists(int id)
        {
            return _context.Employé.Any(e => e.EmpId == id);
        }
    }
}
