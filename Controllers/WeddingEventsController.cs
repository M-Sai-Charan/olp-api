using Microsoft.AspNetCore.Mvc;
using olpApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace olpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingEventsController : ControllerBase
    {
        private static List<WeddingEvent> Events = new();
        private static int currentId = 1;

        private static readonly string dataFilePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "wedding-events.json");

        static WeddingEventsController()
        {
            LoadFromFile();
        }

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
            var year = DateTime.UtcNow.Year;
            newEvent.OlpId = $"{newEvent.Id:D3}OLP{year}";
            newEvent.CreatedOn = DateTime.UtcNow;
            newEvent.UpdatedOn = DateTime.UtcNow;

            Events.Add(newEvent);
            SaveToFile();

            return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent);
        }

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

            SaveToFile();
            return Ok(updatedEvent);
        }

        [HttpDelete("clear")]
        public IActionResult ClearAll()
        {
            Events.Clear();
            currentId = 1;
            SaveToFile();
            return Ok(new { message = "All events cleared." });
        }

        // ------------------------
        // File Persistence Methods
        // ------------------------

        private static void SaveToFile()
        {
            try
            {
                var directory = Path.GetDirectoryName(dataFilePath);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                var json = JsonSerializer.Serialize(Events, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(dataFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving file: " + ex.Message);
            }
        }

        private static void LoadFromFile()
        {
            try
            {
                if (File.Exists(dataFilePath))
                {
                    var json = File.ReadAllText(dataFilePath);
                    var loadedEvents = JsonSerializer.Deserialize<List<WeddingEvent>>(json);
                    if (loadedEvents != null)
                    {
                        Events = loadedEvents;
                        currentId = Events.Any() ? Events.Max(e => e.Id) + 1 : 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading file: " + ex.Message);
            }
        }
    }
}
