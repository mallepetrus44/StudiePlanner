using Microsoft.AspNetCore.Components;
using System;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Models;
using StudiePlanner.Shared.Enums;
using StudiePlanner.Client.Components;

namespace StudiePlanner.Client.Pages
{
    public class CounterBase : ComponentBase
    {
        public PageTitle PageTitle { get; set; }

        public int currentCount = 0;
        [Inject]
        public NotificationService NotificationService { get; set; }
        public async void IncrementCount()
        {
            currentCount++;

            //Console.WriteLine("Incrementing");
            await NotificationService.AddMessage(new Notification(currentCount.ToString(), Notifications.Info));
        }
    }
}
