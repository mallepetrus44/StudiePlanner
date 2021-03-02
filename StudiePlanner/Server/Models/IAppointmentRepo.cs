using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudiePlanner.Shared.Models;

namespace StudiePlanner.Server.Models
{
    public interface IAppointmentRepo
    {
        IEnumerable<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(int appointmentId);
        Appointment AddAppointment(Appointment appointment);
        Appointment UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int appointmentId);
    }
}
