using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>();

        [HttpPost("create")]
        public IActionResult CreateEmployee([FromBody] Employee input)
        {
            string today = DateTime.UtcNow.ToString("yyyyMMdd");
            string prefix = "EMP";
            int count = _employees.Count + 1;
            string generatedPhotographerId = $"{prefix}-{today}-{count:D3}";
            var newEmployee = new Employee
            {
                PhotographerId = generatedPhotographerId,
                Name = input.Name,
                Email = input.Email,
                Phone = input.Phone,
                Address = input.Address,
                JoiningDate = input.JoiningDate,
                ExitDate = input.ExitDate,
                Role = input.Role,
                AllowedRoutes = input.AllowedRoutes,
                TeamId = input.TeamId,
                Status = input.Status,
                Gender = input.Gender,
                Dob = input.Dob,
                Aadhar = input.Aadhar,
                Pan = input.Pan,
                BloodGroup = input.BloodGroup,
                EmergencyContact = input.EmergencyContact,
                CreatedBy = input.CreatedBy,
                LastUpdatedBy = input.CreatedBy,
                ProfilePic = input.ProfilePic
            };

            _employees.Add(newEmployee);

            return Ok(new { message = "Employee created successfully", employee = newEmployee });
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] Employee updated)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return NotFound("Employee not found");

            existing.Name = updated.Name;
            existing.Email = updated.Email;
            existing.Phone = updated.Phone;
            existing.Address = updated.Address;
            existing.JoiningDate = updated.JoiningDate;
            existing.ExitDate = updated.ExitDate;
            existing.Role = updated.Role;
            existing.AllowedRoutes = updated.AllowedRoutes;
            existing.TeamId = updated.TeamId;
            existing.Status = updated.Status;
            existing.Gender = updated.Gender;
            existing.Dob = updated.Dob;
            existing.Aadhar = updated.Aadhar;
            existing.Pan = updated.Pan;
            existing.ProfilePic = updated.ProfilePic;
            existing.BloodGroup = updated.BloodGroup;
            existing.EmergencyContact = updated.EmergencyContact;
            existing.LastUpdated = DateTime.UtcNow;
            existing.LastUpdatedBy = updated.LastUpdatedBy;

            return Ok(new { message = "Employee updated successfully", employee = existing });
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return employee == null ? NotFound() : Ok(employee);
        }

        [HttpDelete("clear")]
        public IActionResult ClearAllEmployees()
        {
            _employees.Clear();
            return Ok(new { message = "All employee data has been cleared." });
        }
    }
}
