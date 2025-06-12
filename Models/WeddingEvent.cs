using System;
using System.Collections.Generic;

namespace olpApi.Models
{
    public class WeddingEvent
    {
        public int Id { get; set; }
        public string OlpId { get; set; } = string.Empty;
        public string Bride { get; set; } = string.Empty;
        public string Groom { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Status { get; set; } = "New";
        public string Location { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public EventNameDetail CalledBy { get; set; } = new();
        public string CallDate { get; set; } = string.Empty;
        public EventStatusDetail CallStatus { get; set; } = new();

        public List<EventDetail> Events { get; set; } = new();
        public string TeamStatus { get; set; } = string.Empty;
    }

    public class EventDetail
    {
        public EventNameDetail EventName { get; set; } = new();
        public string EventDate { get; set; } = string.Empty;
        public string EventLocation { get; set; } = string.Empty;
        public EventNameDetail EventTime { get; set; } = new();
        public string EventGuests { get; set; } = string.Empty;
        public string EventBudget { get; set; } = string.Empty;
        public List<EventTeamMember> EventTeams { get; set; } = new();
    }

    public class EventTeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
    
    public class EventNameDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class EventStatusDetail
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
