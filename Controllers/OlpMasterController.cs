using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using olpApi.Models;

namespace olpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OlpMasterController : ControllerBase
    {
        [HttpGet("getOlpMaster")]
        public IActionResult GetOlpMaster()
        {
            var masterData = new OlpMasterData
            {
                Statuses = new List<DropdownItem>
                {
                    new() { Name = "New", Value = "New" },
                    new() { Name = "In-progress", Value = "In-progress" },
                    new() { Name = "Pending", Value = "Pending" },
                    new() { Name = "Closed", Value = "Closed" },
                    new() { Name = "Blocked", Value = "Blocked" }
                },
                Events = new List<EventNameDetail>
                {
                    new() { Id = 1, Name = "Haldi", Value = "haldi" },
                    new() { Id = 2, Name = "Nalugu", Value = "nalugu" },
                    new() { Id = 3, Name = "Mehandi", Value = "mehandi" },
                    new() { Id = 4, Name = "Sangeeth", Value = "sangeeth" },
                    new() { Id = 5, Name = "Reception", Value = "reception" },
                    new() { Id = 6, Name = "Wedding", Value = "wedding" }
                },
                Employees = new List<EventNameDetail>
                {
                    new() { Id = 1, Name = "John", Value = "john" },
                    new() { Id = 2, Name = "Bose", Value = "bose" },
                    new() { Id = 3, Name = "Stella", Value = "stella" },
                    new() { Id = 4, Name = "Sam", Value = "sam" }
                },
                EventTimes = new List<EventNameDetail>
                {
                    new() { Id = 1, Name = "Early Morning", Value = "morning" },
                    new() { Id = 2, Name = "Afternoon", Value = "afternoon" },
                    new() { Id = 3, Name = "Evening", Value = "evening" },
                    new() { Id = 4, Name = "Night", Value = "night" }
                }
            };

            return Ok(masterData);
        }
    }
}
