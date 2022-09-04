using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using dev_week.src.Models;
using dev_week.src.Persistence;

namespace dev_week.src.Controllers.V1
{
    public class PersonController : DefaultController
    {
        public PersonController(DataContext context) : base(context) { }

        [HttpGet]   
        [Route("v1/people")]             
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.People.Include(p => p.Contracts).ToListAsync();

            if (!result.Any()) return NoContent();

            return Ok(result);
        }        

        [HttpGet]
        [Route("v1/people/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result  = await _context.People.Include(p => p.Contracts).SingleOrDefaultAsync(w => w.Id == id);
            
            if (result == null) return NoContent();                

            return Ok(result);
        }

        [HttpPost]
        [Route("v1/people")]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = person.Id}, person);
        }

        [HttpPut]
        [Route("v1/people/{id:int}")]
        public async Task<IActionResult> Put([FromBody] Person person, int id)
        {
            var result = await _context.People.SingleOrDefaultAsync(w => w.Id == id);

            if (result == null) return BadRequest();

            _context.People.Update(person);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpDelete]
        [Route("v1/people/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _context.People.SingleOrDefaultAsync(w => w.Id == id);

            if (result == null) return BadRequest();

            _context.People.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}