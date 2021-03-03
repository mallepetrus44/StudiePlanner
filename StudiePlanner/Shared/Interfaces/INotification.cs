using StudiePlanner.Shared.Enums;
using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlanner.Shared.Interfaces
{
    public interface INotification
    {
        public string message { get; set; }
        public Notifications notification { get; set; }
    }
}
