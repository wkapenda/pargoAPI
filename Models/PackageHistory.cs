using System;

namespace server_track_trace.Models
{
    public class PackageHistory
    {
        public string Waybill { get; }

        public string Status { get; }
        public DateTime Date { get; }

        public string Location { get; }

        public PackageHistory(string waybill, string status, DateTime date, string location)
        {
            Waybill = waybill;
            Status = status;
            Date = date;
            Location = location;
        }
    }
}
