using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlanner.Shared.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }

    }
}
