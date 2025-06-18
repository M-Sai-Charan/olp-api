using System;
using System.Collections.Generic;

namespace YourNamespace.Models
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Auto-generated
        public string PhotographerId { get; set; } = string.Empty;
        public string SecretCode { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 8);

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public DateTime JoiningDate { get; set; }
        public DateTime? ExitDate { get; set; }

        public EmployeeRole Role { get; set; } = new(); // Default to avoid null

        public List<EmployeeRoutes> AllowedRoutes { get; set; } = new();
        public EmployeeTeam TeamId { get; set; } = new();
        public string Status { get; set; } = "Active";

        public EmployeeTeam Gender { get; set; } = new(); // Used as a value-label pair
        public DateTime Dob { get; set; }

        public string Aadhar { get; set; } = string.Empty;
        public string Pan { get; set; } = string.Empty;
        public string BloodGroup { get; set; } = string.Empty;

        public EmergencyContact EmergencyContact { get; set; } = new();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = "System";
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public string LastUpdatedBy { get; set; } = "System";
    }

    public class EmergencyContact
    {
        public string Name { get; set; } = string.Empty;
        public string Relation { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    public class EmployeeTeam
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class EmployeeRoutes
    {
        public string Label { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
    }

    public class EmployeeRole
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
