using Microsoft.AspNetCore.Components;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Enums;
using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlanner.Client.Pages
{
    public class PageTitleBase : ComponentBase
    {
        [Inject]
        public NotificationService NotificationService { get; set; }

        public PageTitle PageTitle { get; set; }
        public int currentCount = 0;

        public async void IncrementCount()
        {
            currentCount++;
            this.PageTitle.Title = String.Format("Counter: {0}", currentCount);
            //Console.WriteLine("Incrementing");
            await NotificationService.AddMessage(new Notification(currentCount.ToString(), Notifications.Danger));
        }
    }
}
