using Microsoft.AspNetCore.Components;
using StudiePlanner.Shared.Interfaces;
using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudiePlanner.Client.Services
{
    public class NotificationService
    {
        public List<INotification> messages { get; set; } //Type van alert     

        public event Action RefreshRequested;

        public NotificationService()
        {
            this.messages = new List<INotification>();
        }
        public async Task<List<INotification>> AddMessage(Notification notification)
        {
            this.messages.Add(notification);
            RefreshRequested?.Invoke();

            new System.Threading.Timer((_) =>
            {
                this.messages.RemoveAt(0);
                RefreshRequested?.Invoke();
            }, null, 4000, System.Threading.Timeout.Infinite);
            return messages;
        }
    }
}