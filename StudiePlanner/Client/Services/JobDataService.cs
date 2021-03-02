using StudiePlanner.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudiePlanner.Client.Services
{
    public class JobDataService : IJobDataService
    {
        private readonly HttpClient _httpClient;

        public JobDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Job> AddJob(Job job)
        {
            var jobJson =
                new StringContent(JsonSerializer.Serialize(job), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/job", jobJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Job>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteJob(int jobId)
        {
            await _httpClient.DeleteAsync($"api/job/{jobId}");
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Job>>
                 (await _httpClient.GetStreamAsync($"api/job"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Job> GetJobDetails(int jobId)
        {
            return await JsonSerializer.DeserializeAsync<Job>
                (await _httpClient.GetStreamAsync($"api/job/{jobId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateJob(Job job)
        {
            var jobJson =
                  new StringContent(JsonSerializer.Serialize(job), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/job", jobJson);
        }

        public async Task<string> UploadJobDoc(MultipartFormDataContent content)
        {
            var postResult = await _httpClient.PostAsync("api/upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var docUrl = Path.Combine("https://localhost:5011/", postContent);
                return docUrl;
            }
        }
    }
}
