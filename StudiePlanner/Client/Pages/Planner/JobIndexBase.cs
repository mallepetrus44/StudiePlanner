using Microsoft.AspNetCore.Components;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlanner.Client.Pages.Planner
{
    public class JobIndexBase : ComponentBase
    {
        [Inject]
        public IJobDataService JobDataService { get; set; }
        public List<Job> Jobs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Jobs = (await JobDataService.GetAllJobs()).ToList();

        }
    }
}
