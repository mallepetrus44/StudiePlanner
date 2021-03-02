using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudiePlanner.Server.Data;
using StudiePlanner.Shared.Models;

namespace StudiePlanner.Server.Models
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly ApplicationDbContext _mBDbContext;

        public AppointmentRepo(ApplicationDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            var addAppointment = _mBDbContext.Appointments.Add(appointment);
            _mBDbContext.SaveChanges();
            return addAppointment.Entity;
        }

        public void DeleteAppointment(Guid appointmentId)
        {
            var Appointment = _mBDbContext.Appointments.FirstOrDefault(e => e.Id == appointmentId);
            if (Appointment == null) return;

            _mBDbContext.Appointments.Remove(Appointment);
            _mBDbContext.SaveChanges();
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _mBDbContext.Appointments;
        }

        public Appointment GetAppointmentById(Guid appointmentId)
        {
            return _mBDbContext.Appointments.FirstOrDefault(c => c.Id == appointmentId);
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            var updateAppointment = _mBDbContext.Appointments.FirstOrDefault(e => e.Id == appointment.Id);

            if (updateAppointment != null)
            {
                updateAppointment.AppointmentType = appointment.AppointmentType;
                updateAppointment.Detail = appointment.Detail;
                updateAppointment.Date = appointment.Date;
                updateAppointment.Title = appointment.Title;

                _mBDbContext.SaveChanges();

                return updateAppointment;
            }
            return null;
        }
    }
}
