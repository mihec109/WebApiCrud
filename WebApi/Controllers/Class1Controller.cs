using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/Class1")]
    [ApiController]
    public class Class1Controller : ControllerBase
    {
        private readonly Context _context;
        public Class1Controller(Context context)
        {
            _context = context;
        }

        // GET: api/Class1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delavci>>> GetClass1()
        {
            try
            {
                return await _context.DelavciCRUD.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching data.");
            }

        }

        // GET: api/Class1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Delavci>> GetClass1(long id)
        {
            var class1 = await _context.DelavciCRUD.FindAsync(id);

            if (class1 == null)
            {
                return NotFound();
            }

            return class1;
        }

        // PUT: api/Class1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass1(long id, Delavci class1)
        {
            if (id != class1.Id)
            {
                return BadRequest();
            }

            _context.Entry(class1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Class1Exists(id))
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

        // POST: api/Class1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Delavci>> PostClass1(Delavci class1)
        {
            _context.DelavciCRUD.Add(class1);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClass1), new { id = class1.Id }, class1);
        }

        // DELETE: api/Class1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Delavci>> DeleteClass1(int id)
        {
            var class1 = await _context.DelavciCRUD.FindAsync(id);

            if (class1 == null)
            {
                return NotFound();
            }

            _context.DelavciCRUD.Remove(class1);
            await _context.SaveChangesAsync();

            return class1;
        }

        private bool Class1Exists(long id)
        {
            return _context.DelavciCRUD.Any(e => e.Id == id);
        }
    }
}
