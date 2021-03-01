using StudiePlanner.Server.Data;
using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudiePlanner.Server.Models
{
    public class JobRepo : IJobRepo
    {

        private readonly ApplicationDbContext _mBDbContext;

        public JobRepo(ApplicationDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }

        public Job AddJob(Job job)
        {
            var addJob = _mBDbContext.Jobs.Add(job);
            _mBDbContext.SaveChanges();
            return addJob.Entity;
        }

        public void DeleteJob(int jobId)
        {
            var Job = _mBDbContext.Jobs.FirstOrDefault(e => e.Id == jobId);
            if (Job == null) return;

            _mBDbContext.Jobs.Remove(Job);
            _mBDbContext.SaveChanges();
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return _mBDbContext.Jobs;
        }

        public Job GetJobById(int jobId)
        {
            return _mBDbContext.Jobs.FirstOrDefault(c => c.Id == jobId);
        }

        public Job UpdateJob(Job job)
        {
            var updateJob = _mBDbContext.Jobs.FirstOrDefault(e => e.Id == job.Id);

            if (updateJob != null)
            {
                updateJob.Name = job.Name;
                updateJob.Detail = job.Detail;
                updateJob.Status = job.Status;
                updateJob.StartDate = job.StartDate;
                updateJob.EndDate = job.EndDate;
                updateJob.DateAdded = DateTime.Now;

                _mBDbContext.SaveChanges();

                return updateJob;
            }
            return null;
        }
        public MultipartFormDataContent UploadJobDoc(MultipartFormDataContent content)
        {
            throw new NotImplementedException();
        }
    }
}