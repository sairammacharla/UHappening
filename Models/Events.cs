using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UHappeningServices.Models
{
    public class Events
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string EventType { get; set; }

        public string Location { get; set; }

        public bool isPrivate { get; set; }

        public string EventDesc { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int Capacity { get; set; }

        public int CreatedBy { get; set; }
    }
}