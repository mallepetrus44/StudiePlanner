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

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Jobs = (await JobDataService.GetAllJobs()).ToList();

        }

        protected async Task CheckAllDates()
        {
            foreach (var job in Jobs)
            {
                if(job.EndDate <= DateTime.Now)
                {
                    StatusClass = "alert-danger";
                    //Message = ($"{0} is nog niet afgerond: De einddatum is {1}", job.Name, job.EndDate.());
                    Saved = true;
                }
            }
        }
    }
}
