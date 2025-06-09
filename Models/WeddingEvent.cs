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
        public string Location { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }

        public string CalledBy { get; set; } = string.Empty;
        public string CallDate { get; set; } = string.Empty;
        public string CallStatus { get; set; } = string.Empty;

        public List<EventDetail> Events { get; set; } = new();
    }

    public class EventDetail
    {
        public EventNameDetail EventName { get; set; } = new();
        public string EventDate { get; set; } = string.Empty;
        public string EventLocation { get; set; } = string.Empty;
        public string EventTime { get; set; } = string.Empty;
        public string EventGuests { get; set; } = string.Empty;
        public string EventBudget { get; set; } = string.Empty;
    }

    public class EventNameDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
