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
        protected string StatusHeadingClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Jobs = (await JobDataService.GetAllJobs()).ToList();
            await Task.Run(()=> CheckAllDates());
        }

        protected Task CheckAllDates()
        {
            foreach (var job in Jobs)
            {
                if(job.EndDate <= DateTime.Now)
                {
                    StatusClass = "alert-danger";
                    Message += "De einddatum voor opdracht " + job.Name + " is verstreken \n";
                }
            }

            return Task.CompletedTask;
        }
    }
}
