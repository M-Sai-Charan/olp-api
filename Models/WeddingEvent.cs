using System;
using System.Collections.Generic;

namespace olpApi.Models
{
    public class PreWeddingEvent
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class WeddingEvent
    {
        public int Id { get; set; }
        public string Bride { get; set; } = string.Empty;
        public string Groom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public List<PreWeddingEvent> Pre_Wedding { get; set; } = new List<PreWeddingEvent>();
        public DateTime Timestamp { get; set; }
    }
}
