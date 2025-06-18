using System;
using System.Collections.Generic;

namespace YourNamespace.Models
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Auto-generated
        public string PhotographerId { get; set; }
        public string SecretCode { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 8);

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public DateTime JoiningDate { get; set; }
        public DateTime? ExitDate { get; set; }

        public EmployeeRole  Role { get; set; }

        public List<EmployeeRoutes> AllowedRoutes { get; set; } = new List<string>();
        public EmployeeTeam  TeamId { get; set; }
        public string Status { get; set; }

        public EmployeeTeam  Gender { get; set; }
        public DateTime Dob { get; set; }

        public string Aadhar { get; set; }
        public string Pan { get; set; }
        public string BloodGroup { get; set; }

        public EmergencyContact EmergencyContact { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public string LastUpdatedBy { get; set; }
    }

    public class EmergencyContact
    {
        public string Name { get; set; }
        public string Relation { get; set; }
        public string Phone { get; set; }
    }

    public class EmployeeTeam
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class EmployeeRoutes
    {
        public string Label { get; set; }
        public string Icon { get; set; }
        public string route { get; set; }
    }

     public class EmployeeRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
