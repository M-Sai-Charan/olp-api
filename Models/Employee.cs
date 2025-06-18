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

        public string Role { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }

        public List<string> AllowedRoutes { get; set; } = new List<string>();
        public string TeamId { get; set; }
        public string Status { get; set; }

        public string ProfilePic { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }

        public string Aadhar { get; set; }
        public string Pan { get; set; }
        public string BloodGroup { get; set; }

        public EmergencyContact EmergencyContact { get; set; }

        public string Notes { get; set; }
        public double Rating { get; set; }

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
}
