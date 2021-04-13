using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingController : ControllerBase
    {
        private readonly ThingContext _context;

        public ThingController(ThingContext context)
        {
            _context = context;
        }

        // GET: api/Things
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thing>>> GetThings()
        {
            return await _context.Things.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Thing>> GetThing(long id)
        {
            var thing = await _context.Things.FindAsync(id);

            if (thing == null)
            {
                return NotFound();
            }
            return thing;
        }

        [HttpPost]
        public async Task<ActionResult<Thing>> CreateThing(Thing thing)
        {
            _context.Things.Add(thing);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetThing), new { id = thing.Id }, thing);
        }
    }
}
