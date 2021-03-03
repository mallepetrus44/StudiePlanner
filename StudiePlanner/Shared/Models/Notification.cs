using StudiePlanner.Shared.Enums;
using StudiePlanner.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlanner.Shared.Models
{
    public class Notification : INotification
    {
        public Notification() { }
        public Notification(string message, Notifications notification)
        {
            this.message = message;
            this.notification = notification;
        }
        public string message { get; set; }
        public Notifications notification { get; set; }
    }
}
