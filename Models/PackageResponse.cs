using System;

namespace server_track_trace.Models
{
    public class PackageResponse
    {
        public string Status { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
