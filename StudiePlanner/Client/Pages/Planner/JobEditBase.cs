using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using StudiePlanner.Client.Services;
using StudiePlanner.Shared.Models;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudiePlanner.Client.Pages.Planner
{
    public class JobEditBase : ComponentBase
    {
        [Inject]
        public IJobDataService JobDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public Job Job { get; set; } = new Job();


        [Parameter]
        public string Id { get; set; }

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        protected override async Task OnInitializedAsync()
        {
            Saved = false;


            int.TryParse(Id, out var JobID);

            if (JobID == 0) //new job is being created
            {
                //add some defaults
                Job = new Job { 
                
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    DateAdded = DateTime.Now
                };
            }
            else
            {
                Job = await JobDataService.GetJobDetails(int.Parse(Id));
            }


        }

        protected async Task HandleValidSubmit()
        {


            if (Job.Id == 0) //new
            {
                var addedJob = await JobDataService.AddJob(Job);
                if (addedJob != null)
                {
                    StatusClass = "alert-success";
                    Message = "Nieuwe klant succesvol toegevoegd.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Er is iets misgegaan tijdens het aanmaken van een nieuwe klant. Probeer het opnieuw.";
                    Saved = false;
                }
            }
            else
            {
                await JobDataService.UpdateJob(Job);
                StatusClass = "alert-success";
                Message = "Klantgegevens zijn succesvol bijgewerkt.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteJob()
        {
            await JobDataService.DeleteJob(Job.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Planner/JobIndex");
        }




        // using BlazorInputFile library zorgt dat er gebruik gemaakt kan worden van de Interface IFileListEntry
        public IFileListEntry File { get; set; }


        // De InputFile tag in de html triggerd een onchange event HandleFileSelected
        // Welk bestand komt er binnen (NOG geen restricties geïmplementeerd)
        public async Task HandleFileSelected(IFileListEntry[] files)
        {
            File = files.FirstOrDefault();
            if (File != null)
            {
                // Een MemoryStream verwerkt data in het geheugen ipv op de schijf. Dit is sneller en zorgt ervoor dat het
                // bestand niet geblokkeerd wordt.

                var ms = new MemoryStream();

                // De interface IFileListEntry heeft een member Data (Een abstract class Stream)
                // De memoryStream gebruiken om de Data (Stream) in te kopiëren.
                await File.Data.CopyToAsync(ms);


                // MultipartFormDataContent aan maken (onderdeel van System.Net.Http)
                var content = new MultipartFormDataContent
             {
                    //  Bestand bufferen uit geheugen aan de hand van de MemoryStream
                 { new ByteArrayContent(ms.GetBuffer()), "\"Upload\"", File.Name }
             };

                // content (MultipartFormDataContent uit geheugen gebufferd) meegeven aan JobDataService (method => UploadJobImage)
                await JobDataService.UploadJobDoc(content);
            }
        }
    }
}
