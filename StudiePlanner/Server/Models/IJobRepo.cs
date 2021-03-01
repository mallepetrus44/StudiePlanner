using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudiePlanner.Server.Models
{
    public interface IJobRepo
    {
        IEnumerable<Job> GetAllJobs();
        Job GetJobById(Guid jobId);
        Job AddJob(Job job);
        Job UpdateJob(Job job);
        void DeleteJob(Guid jobId);
        Job UploadJobDoc(MultipartFormDataContent content);
    }
}
