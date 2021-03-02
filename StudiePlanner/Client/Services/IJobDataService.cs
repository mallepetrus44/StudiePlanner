using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudiePlanner.Client.Services
{
    public interface IJobDataService
    {
        Task<IEnumerable<Job>> GetAllJobs();
        Task<Job> GetJobDetails(int jobId);
        Task<Job> AddJob(Job job);
        Task UpdateJob(Job job);
        Task DeleteJob(int jobId);
        Task<string> UploadJobDoc(MultipartFormDataContent content);
    }
}
