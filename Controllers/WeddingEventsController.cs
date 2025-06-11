using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using olpApi.Models;

namespace olpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingEventsController : ControllerBase
    {
        private static readonly string FilePath = Path.Combine("App_Data", "wedding-events.json");

        private List<WeddingEvent> LoadEvents()
        {
            if (!System.IO.File.Exists(FilePath)) return new List<WeddingEvent>();
            var json = System.IO.File.ReadAllText(FilePath);
            return string.IsNullOrWhiteSpace(json)
                ? new List<WeddingEvent>()
                : JsonSerializer.Deserialize<List<WeddingEvent>>(json);
        }

        private void SaveEvents(List<WeddingEvent> events)
        {
            var json = JsonSerializer.Serialize(events, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            System.IO.File.WriteAllText(FilePath, json);
        }

        // GET: api/WeddingEvents
        [HttpGet]
        public IActionResult GetAll()
        {
            var events = LoadEvents();
            return Ok(events);
        }

        // GET: api/WeddingEvents/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var events = LoadEvents();
            var ev = events.FirstOrDefault(e => e.Id == id);
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

            var events = LoadEvents();
            int newId = events.Count > 0 ? events.Max(e => e.Id) + 1 : 1;
            newEvent.Id = newId;
            newEvent.OlpId = $"{newId.ToString("D3")}OLP{DateTime.UtcNow.Year}";
            newEvent.CreatedOn = DateTime.UtcNow;
            newEvent.UpdatedOn = DateTime.UtcNow;

            events.Add(newEvent);
            SaveEvents(events);

            return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent);
        }

        // PUT: api/WeddingEvents/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] WeddingEvent updatedEvent)
        {
            var events = LoadEvents();
            var existing = events.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return NotFound();

            updatedEvent.Id = existing.Id;
            updatedEvent.CreatedOn = existing.CreatedOn;
            updatedEvent.UpdatedOn = DateTime.UtcNow;

            var index = events.IndexOf(existing);
            events[index] = updatedEvent;
            SaveEvents(events);

            return Ok(updatedEvent);
        }

        // DELETE: api/WeddingEvents/clear
        [HttpDelete("clear")]
        public IActionResult ClearAll()
        {
            SaveEvents(new List<WeddingEvent>());
            return Ok(new { message = "All events cleared." });
        }
    }
}
