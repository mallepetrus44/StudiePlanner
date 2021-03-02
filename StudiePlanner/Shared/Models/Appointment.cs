using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlanner.Shared.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AppointmentType AppointmentType { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Detail { get; set; }
        public string JobId { get; set; }

    }
}
