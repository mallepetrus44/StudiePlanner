using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Models;

namespace StudiePlanner.Client.Pages.AppointmentPages
{
    public class AppointmentDeleteBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        public Appointment Appointment { get; set; } = new Appointment();

        public IEnumerable<Appointment> Appointments { get; set; }
        [Inject]
        public IAppointmentDataService AppointmentDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }



        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async override Task OnInitializedAsync()
        {
            Appointment = await AppointmentDataService.GetAppointmentDetails(int.Parse(Id));

        }

        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/AppointmentPages/AppointmentIndex");
        }

        protected async Task DeleteAppointment()
        {
            await AppointmentDataService.DeleteAppointment(Appointment.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;

            NavigationManager.NavigateTo("/AppointmentPages/AppointmentIndex");
        }
    }
}

