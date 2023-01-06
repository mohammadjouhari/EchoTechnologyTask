using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;

namespace JobApplicationFormWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public bool ShowExpereince { get; set; }
        public bool IsFormSubmitted { get; set; }

        public List<JobApplicationExpereince> Experinces { get; set; }

        [BindProperty]
        public IFormFile profileImage { get; set; }
        public void OnPost()
        {
            ShowExpereince = false;
            IsFormSubmitted = false;
            var jobApplication = new JobApplication();
            jobApplication.Name = Request.Form["name"];
            jobApplication.DateOfBith = DateTime.Parse(Request.Form["date"]);
            jobApplication.Expereince = Request.Form["expJson"];
            Experinces = JsonConvert.DeserializeObject<List<JobApplicationExpereince>>(jobApplication.Expereince);
            // Save Image in wwwroot;
            var fileName = Path.GetFileName(profileImage.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                profileImage.CopyTo(fileStream);
            }
            jobApplication.ProfileImage = fileName;

            if(Experinces != null)
            {
                foreach (var item in Experinces)
                {
                    Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                    var base64File = regex.Replace(item.experienceFile, string.Empty);
                    Byte[] bytes = Convert.FromBase64String(base64File);
                    var fileName2 = item.fileName;
                    var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Documents\", item.fileName);
                    System.IO.File.WriteAllBytes(filePath2, bytes);
                    item.experienceFile = "";
                }
                jobApplication.Expereince = JsonConvert.SerializeObject(Experinces);
              
            }
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
            "/api/JobApplication/Add";
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string Json = Newtonsoft.Json.JsonConvert.SerializeObject(jobApplication);
                client.UploadString(apiUrl, Json);
            }
            IsFormSubmitted = true;
        }
    }
}