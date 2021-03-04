using Blazored.Toast.Services;
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
        public IToastService ToastService { get; set; }

        [Inject]
        public IJobDataService JobDataService { get; set; }

        public string dagenswitch { get; set; }   
        public List<Job> Jobs { get; set; }
    
        public int currentCount { get; set; }

        protected string Message = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Jobs = (await JobDataService.GetAllJobs()).ToList();
            await Task.Run(()=> Getid());
        }
        public async Task Getid()
        {

            foreach (var job in Jobs)
            {
                if (job.EndDate <= DateTime.Now)
                {
                    currentCount = job.Id;
                    Message = "Opdracht: " + currentCount.ToString() + " is te laat";
                    //await NotificationService.AddMessage(new Notification(Message, Notifications.Danger));
                    await Task.Run(()=>ToastService.ShowError(Message.ToString()));

                }

            }
        }
    }
}
        