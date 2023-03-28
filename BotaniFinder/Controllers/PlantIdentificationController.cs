using BotaniFinder.Context;
using BotaniFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotaniFinder.Controllers
{
    public class PlantIdentificationController : Controller
    {
        //The BotaniFinderDbContext is injected into the controller using dependency injection, with the constructor.
        //This follows the Dependency Inversion Principle in the SOLID principles.
        private readonly BotaniFinderDbContext _dbContext;
        private readonly string _plantNetApiUrl = "https://my-api.plantnet.org/v2/identify/all?include-related-images=true&no-reject=true&lang=en&api-key=2b10JXYocEFbfuM3nMDtQa93e";

        public PlantIdentificationController(BotaniFinderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //IActionResult is a return type that can return a JSON object or View
        public IActionResult Index()
        {
            return View();
        }
        //HttpPost specifies that the method is only called when the HTTP request is a POST.
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile image)
        {
            // if the image is null or the length is 0, an error message is added to the ModelState.
            if (image == null || image.Length == 0)
            {
                ModelState.AddModelError("image", "Please select a file to upload.");
                return View();
            }



            // OpenReadStream is used to open the file as a stream.
            using var stream = image.OpenReadStream();
            // httpClient sends and receives HTTP requests and responses.
            using var httpClient = new HttpClient();
            //The MultipartFormDataContent class is used to send data requests.
            using var content = new MultipartFormDataContent();
            //The StreamContent class is used to send the image as a stream.
            content.Add(new StreamContent(stream), "images", image.FileName);

            //MediaTypeWithQualityHeaderValues are used to specify the type of the response in this case it's application/json.
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // response is the result of the POST request. It's Async because it's a task.
            var response = await httpClient.PostAsync(_plantNetApiUrl, content);


            //If the response is not successful, an error message is added.
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("image", "Error occurred while calling the PlantNet API.");
                return View();
            }


            //The response is read as a string and then deserialized into a Root object. 
            //The Root object is then used to create a new PlantIdentificationResult object.
            //This is the await from the Async task.
            var responseContent = await response.Content.ReadAsStringAsync();
            var plantIdentificationResult = JsonConvert.DeserializeObject<Root>(responseContent);
            var newPlantIdentificationResult = new PlantIdentificationResult
            {
                //These are the properties of the PlantIdentificationResult object.
                // The plantIdentificationResult.Results is a list of Result objects.
                Score = plantIdentificationResult.Results[0].Score,
                Species = plantIdentificationResult.Results[0].Species,
                Image = plantIdentificationResult.Results[0].Image,
            };
            //save changes to database and return the view.
            var newUrl = new Url
            {
                O = plantIdentificationResult.Results[0].Image[0].Url.O,
                M = plantIdentificationResult.Results[0].Image[0].Url.M,
                S = plantIdentificationResult.Results[0].Image[0].Url.O,
            };
            _dbContext.Urls.Add(newUrl);
            await _dbContext.SaveChangesAsync();
            // This is the await from the Async task in the Index method.
            return View(plantIdentificationResult);
        }
    }
}
