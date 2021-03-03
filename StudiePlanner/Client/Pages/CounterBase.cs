using Microsoft.AspNetCore.Components;
using System;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Models;
using StudiePlanner.Shared.Enums;
using StudiePlanner.Client.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace StudiePlanner.Client.Pages
{
    public class CounterBase : ComponentBase
    {
        [Inject]
        public NotificationService NotificationService { get; set; }
        [Inject]
        public IJobDataService JobDataService { get; set; }
        public List<Job> Jobs { get; set; }
        public string Message { get; set; }
        public PageTitle PageTitle { get; set; }

        public int currentCount { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Jobs = (await JobDataService.GetAllJobs()).ToList();

        }

        public async void Getid()
        {
           
            foreach (var job in Jobs)
            {
                if (job.EndDate <= DateTime.Now)
                {
                    currentCount = job.Id;
                    Message = "Opdracht: " + currentCount.ToString() + " is te laat";
                    await NotificationService.AddMessage(new Notification(Message, Notifications.Danger));
                }
                
            }
        }
    }
}
