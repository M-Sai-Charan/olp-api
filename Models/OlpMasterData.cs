using System.Collections.Generic;

namespace olpApi.Models
{
    public class OlpMasterData
    {
        public List<DropdownItem> Statuses { get; set; } = new();
        public List<EventNameDetail> Events { get; set; } = new();
        public List<EventNameDetail> Employees { get; set; } = new();
        public List<EventNameDetail> EventTimes { get; set; } = new();
        public List<EventNameDetail> OlpAssignTeams { get; set; } = new();
        public List<EventNameDetail> OlpInventories { get; set; } = new();
        public List<RoleMasterItem> Roles { get; set; } = new();
    }

    public class DropdownItem
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
    public class RoleMasterItem
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
}
