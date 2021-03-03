using Microsoft.AspNetCore.Components;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlanner.Client.Pages.Planner
{
    public class JobDeleteBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        public Job Job { get; set; } = new Job();
        public IEnumerable<Job> Jobs { get; set; }
        public Appointment Appointment { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        [Inject]
        public IJobDataService JobDataService { get; set; }
        [Inject]
        public IAppointmentDataService AppointmentDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }



        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async override Task OnInitializedAsync()
        {
            Job = await JobDataService.GetJobDetails(int.Parse(Id));
            Appointments = await AppointmentDataService.GetAllAppointments();
        }

        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/Planner/JobIndex");
        }

        protected async Task DeleteJob()
        {
            
            foreach(var appointment in Appointments.Where(a =>a.JobId == Job.Id))
            {
               await AppointmentDataService.DeleteAppointment(appointment.Id);
            }
            await JobDataService.DeleteJob(Job.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;

            NavigationManager.NavigateTo("/Planner/JobIndex");
        }
    }
}
