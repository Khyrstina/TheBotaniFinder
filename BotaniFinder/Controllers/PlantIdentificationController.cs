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
        private readonly BotaniFinderDbContext _dbContext;
        private readonly string _plantNetApiUrl = "https://my-api.plantnet.org/v2/identify/all?include-related-images=true&no-reject=true&lang=en&api-key=2b10JXYocEFbfuM3nMDtQa93e";

        public PlantIdentificationController(BotaniFinderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                ModelState.AddModelError("image", "Please select a file to upload.");
                return View();
            }

            using var stream = image.OpenReadStream();

            using var httpClient = new HttpClient();

            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(stream), "images", image.FileName);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.PostAsync(_plantNetApiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("image", "Error occurred while calling the PlantNet API.");
                return View();
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var plantIdentificationResult = JsonConvert.DeserializeObject<Root>(responseContent);
            var newPlantIdentificationResult = new PlantIdentificationResult
            {
                Score = plantIdentificationResult.Results[0].Score,
                Species = plantIdentificationResult.Results[0].Species,
                Image = plantIdentificationResult.Results[0].Image,
                //Gbif = plantIdentificationResult.Results[0].Gbif
            };
            //Save the result to the database
            _dbContext.PlantIdentificationResults.Add(newPlantIdentificationResult);
            await _dbContext.SaveChangesAsync();

            return View(plantIdentificationResult);
        }
    }
}
