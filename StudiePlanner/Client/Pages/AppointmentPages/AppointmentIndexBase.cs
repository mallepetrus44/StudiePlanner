using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Models;

namespace StudiePlanner.Client.Pages.AppointmentPages
{
    public class AppointmentIndexBase : ComponentBase
    {
        [Inject]
        public IAppointmentDataService AppointmentDataService { get; set; }
        public List<Appointment> Appointments { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Appointments = (await AppointmentDataService.GetAllAppointments()).ToList();

        }
    }
}
