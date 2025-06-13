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
                },
                OlpAssignTeams = new List<EventNameDetail>
                {
                    new() { Id = 1, Name = "Steve", Value = "photographer" },
                    new() { Id = 2, Name = "Max", Value = "photographer" },
                    new() { Id = 3, Name = "Hazel", Value = "photographer" },
                    new() { Id = 4, Name = "Warner", Value = "photographer" },
                    new() { Id = 5, Name = "Smith", Value = "editor" },
                    new() { Id = 6, Name = "Pollard", Value = "editor" },
                    new() { Id = 7, Name = "Pooran", Value = "editor" },
                    new() { Id = 8, Name = "Gayle", Value = "editor" },
                    new() { Id = 9, Name = "Ferguson", Value = "lightman" },
                    new() { Id = 10, Name = "Markram", Value = "lightman" },
                    new() { Id = 11, Name = "Narine", Value = "lightman" },
                    new() { Id = 12, Name = "Rashid", Value = "lightman" },
                    new() { Id = 13, Name = "Archer", Value = "droneoperator" },
                    new() { Id = 14, Name = "Kane", Value = "droneoperator" },
                    new() { Id = 15, Name = "Williams", Value = "droneoperator" },
                    new() { Id = 16, Name = "Daniel", Value = "droneoperator" },
                    new() { Id = 17, Name = "Bob", Value = "videographer" },
                    new() { Id = 18, Name = "Charlie", Value = "videographer" },
                    new() { Id = 19, Name = "Stephene", Value = "videographer" },
                    new() { Id = 20, Name = "Alice", Value = "videographer" }
                }
                OlpInventories = new List<EventNameDetail>
                {
                    new()  { Id= 1, Name= 'Canon EOS R5', Value= 'camera' },
                    new()  { Id= 2, Name= 'Nikon Z9', Value= 'camera' },
                    new()  { Id= 3, Name= 'Sony A7S III', Value= 'camera' },
                    new()  { Id= 4, Name= 'Manfrotto Tripod', Value= 'tripod' },
                    new()  { Id= 5, Name= 'Benro Tripod', Value= 'tripod' },
                    new()  { Id= 6, Name= 'Godox LED Panel', Value= 'lighting' },
                    new()  { Id= 7, Name= 'Aputure Light Storm', Value= 'lighting' },
                    new()  { Id= 8, Name= 'DJI Mavic 3', Value= 'drone' },
                    new()  { Id= 9, Name= 'DJI Air 2S', Value= 'drone' },
                    new()  { Id= 10, Name= 'Zhiyun Crane 3S', Value= 'gimbal' },
                    new()  { Id= 11, Name= 'DJI Ronin-S', Value= 'gimbal' }
                }
            };

            return Ok(masterData);
        }
    }
}
