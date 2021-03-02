﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Models;

namespace StudiePlanner.Client.Pages.AppointmentPages
{
    public class AppointmentEditBase : ComponentBase
    {
        [Inject]
        public IAppointmentDataService AppointmentDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public Appointment Appointment { get; set; } = new Appointment();


        [Parameter]
        public string Id { get; set; }

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        protected override async Task OnInitializedAsync()
        {
            Saved = false;


            int.TryParse(Id, out var AppointmentID);

            if (AppointmentID == 0) //new Customer is being created
            {
                //add some defaults
                Appointment = new Appointment {
                Date =DateTime.Now
                };
            }
            else
            {
                Appointment = await AppointmentDataService.GetAppointmentDetails(int.Parse(Id));
            }


        }

        protected async Task HandleValidSubmit()
        {


            if (Appointment.Id == 0) //new
            {
                var addedAppointment = await AppointmentDataService.AddAppointment(Appointment);
                if (addedAppointment != null)
                {
                    StatusClass = "alert-success";
                    Message = "Nieuwe afspraak succesvol toegevoegd.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Er is iets misgegaan tijdens het aanmaken van een nieuwe afspraak. Probeer het opnieuw.";
                    Saved = false;
                }
            }
            else
            {
                await AppointmentDataService.UpdateAppointment(Appointment);
                StatusClass = "alert-success";
                Message = "Afspraakgegevens zijn succesvol bijgewerkt.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteAppointment()
        {
            await AppointmentDataService.DeleteAppointment(Appointment.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/AppointmentPages/AppointmentIndex");
        }
    }
}