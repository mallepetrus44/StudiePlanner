using Microsoft.AspNetCore.Components;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlanner.Client.Pages.Planner
{
    public class JobDetailBase : ComponentBase
    {
        [Inject]
        public IJobDataService JobDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Job Job { get; set; } = new Job();

        protected override async Task OnInitializedAsync()
        {
            Job = await JobDataService.GetJobDetails(int.Parse(Id));

        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Planner/JobIndex");
        }
    }
}
