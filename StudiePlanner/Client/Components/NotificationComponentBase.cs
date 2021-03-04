using Microsoft.AspNetCore.Components;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlanner.Client.Components
{
    public class NotificationComponentBase : ComponentBase
    {
        [Inject]
        public NotificationService NotificationService { get; set; }
        protected override void OnInitialized()
        {
            //Console.WriteLine("AlertComponent:Initializied");
            NotificationService.RefreshRequested += Refresh;
        }

        public String getAlertClass(INotification notification)
        {
            return String.Format("alert-{0}", notification.notification.ToString().ToLower());
        }

        private void Refresh()
        {
            //Console.WriteLine("AlertComponent:refreshing");
            StateHasChanged();
        }
    }
}
