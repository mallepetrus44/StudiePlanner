using Microsoft.AspNetCore.Components;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Enums;
using StudiePlanner.Shared.Interfaces;
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
        [Inject]
        public NotificationService NotificationService { get; set; }

        public string dagenswitch { get; set; }
        public Notification notification { get; set; }
        public List<Job> Jobs { get; set; }
        public List<INotification> Messages { get; set; }

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Jobs = (await JobDataService.GetAllJobs()).ToList();
        }
        //    await Task.Run(()=>JustDoIt());
            
        //}
        //public async void JustDoIt()
        //{
        //    foreach (var job in Jobs)
        //    {
        //        if (job.EndDate <= DateTime.Now)
        //        {
        //            var dagenvertraagd = DateTime.Now.Subtract(job.EndDate).TotalDays;
        //            if (dagenvertraagd == 1)
        //            {
        //                dagenswitch = "dag";
        //            }
        //            dagenswitch = "dagen";


        //            notification.message = ($"Taak {job.Name}is niet tijdig afgerond!" + Environment.NewLine + $"Huidige datum : {DateTime.Now.Date}" + Environment.NewLine + $"De eindatum is : {job.EndDate.Date}" + Environment.NewLine + $"U bent {dagenvertraagd} {dagenswitch} te laat");
        //        }
        //        continue;
        //    }
        //    await NotificationService.AddMessage(new Notification(Message.ToString(), Notifications.Danger));
        //}
    }
}
