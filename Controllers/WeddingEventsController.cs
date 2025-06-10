using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using olpApi.Models;

namespace olpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingEventsController : ControllerBase
    {
        private static readonly List<WeddingEvent> Events = new();
        private static int currentId = 1;

        // GET: api/WeddingEvents
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Events);
        }

        // GET: api/WeddingEvents/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ev = Events.FirstOrDefault(e => e.Id == id);
            if (ev == null)
                return NotFound();
            return Ok(ev);
        }

        // POST: api/WeddingEvents
        [HttpPost]
        public IActionResult Create([FromBody] WeddingEvent newEvent)
        {
            if (newEvent == null)
                return BadRequest("Invalid data.");

            newEvent.Id = currentId++;
            newEvent.CreatedOn = DateTime.UtcNow;
            newEvent.UpdatedOn = DateTime.UtcNow;

            Events.Add(newEvent);

            return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent);
        }

        // PUT: api/WeddingEvents/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] WeddingEvent updatedEvent)
        {
            var existing = Events.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return NotFound();

            updatedEvent.Id = existing.Id;
            updatedEvent.CreatedOn = existing.CreatedOn;
            updatedEvent.UpdatedOn = DateTime.UtcNow;

            var index = Events.IndexOf(existing);
            Events[index] = updatedEvent;

            return Ok(updatedEvent);
        }

        // DELETE: api/WeddingEvents/clear
        [HttpDelete("clear")]
        public IActionResult ClearAll()
        {
            Events.Clear();
            currentId = 1;
            return Ok(new { message = "All events cleared." });
        }
    }
}
