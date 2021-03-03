using StudiePlanner.Shared.Interfaces;
using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlanner.Shared.Services
{
    class NotificationService
    {
        public List<INotification> messages { get; set; }
        public event Action RefreshRequested;

        public NotificationService()
        {
            this.messages = new List<INotification>();
        }
        public async Task<List<INotification>> AddMessage(Notification notification)
        {
           this.messages.Add(notification);
            RefreshRequested?.Invoke();

            // pop message off after a delay
            new System.Threading.Timer((_) =>
            {
                this.messages.RemoveAt(0);
                RefreshRequested?.Invoke();
            }, null, 8000, System.Threading.Timeout.Infinite);
            return messages;
        }
    }
}
