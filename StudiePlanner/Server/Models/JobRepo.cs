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

        public void DeleteJob(Guid jobId)
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

        public Job GetJobById(Guid jobId)
        {
            return _mBDbContext.Jobs.FirstOrDefault(c => c.Id == jobId);
        }

        public Job UpdateJob(Job job)
        {
            var updateJob = _mBDbContext.Jobs.FirstOrDefault(e => e.Id == job.Id);

            if (updateJob != null)
            {
                //updateJob.Voornaam = job.Voornaam;
                //updateJob.Achternaam = job.Achternaam;
                //updateJob.Adres = job.Adres;
                //updateJob.Postcode = job.Postcode;
                //updateJob.Logo = job.Logo;
                //updateJob.KvkNummer = job.KvkNummer;
                //updateJob.BtwNummer = job.BtwNummer;
                //updateJob.Stad = job.Stad;
                //updateJob.Goedgekeurd = false;

                _mBDbContext.SaveChanges();

                return updateJob;
            }
            return null;
        }
        public Job UploadJobDoc(MultipartFormDataContent content)
        {
            throw new NotImplementedException();
        }
    }
}