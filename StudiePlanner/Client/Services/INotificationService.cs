using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlanner.Client.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Job>> GetAllJobs();
    }
}
