﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Models;

namespace StudiePlanner.Client.Pages.AppointmentPages
{
    public class AppointmentDetailBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        public Appointment Appointment { get; set; } = new Appointment();

        public IEnumerable<Appointment> Appointments { get; set; }
        [Inject]
        public IAppointmentDataService AppointmentDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Appointment = await AppointmentDataService.GetAppointmentDetails(int.Parse(Id));

        }

        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/AppointmentPages/AppointmentIndex");
        }
    }
}