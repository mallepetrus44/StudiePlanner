using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlanner.Shared.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Notification { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public string Upload { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
