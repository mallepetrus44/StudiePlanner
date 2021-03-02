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
        Job GetJobById(int jobId);
        Job AddJob(Job job);
        Job UpdateJob(Job job);
        void DeleteJob(int jobId);
        MultipartFormDataContent UploadJobDoc(MultipartFormDataContent content);
    }
}
