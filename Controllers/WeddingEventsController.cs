
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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Events);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ev = Events.FirstOrDefault(e => e.Id == id);
            if (ev == null)
                return NotFound();
            return Ok(ev);
        }

        [HttpPost]
        public IActionResult Create([FromBody] WeddingEvent newEvent)
        {
            if (newEvent == null)
                return BadRequest("Invalid data.");

            newEvent.Id = currentId++;
            newEvent.Timestamp = DateTime.UtcNow;

            Events.Add(newEvent);

            return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent);
        }
    }
}
