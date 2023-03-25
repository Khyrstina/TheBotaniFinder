using BotaniFinder.Context;
using BotaniFinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace BotaniFinder.Controllers
{
    //This controller only has one purpose, which is to return the previous identifications from the database.
    //This uses the Single Responsibility Principle in the SOLID principles.
    public class PreviousIdentificationsFromDatabaseController : Controller
    {
        //The BotaniFinderDbContext is injected into the controller using dependency injection, with the constructor.
        //This follows the Dependency Inversion Principle in the SOLID principles.
        private readonly BotaniFinderDbContext _context;

        public PreviousIdentificationsFromDatabaseController(BotaniFinderDbContext context)
        {
           
            _context = context;
        }
        public IActionResult Index()
        {
            //images takes the Urls table from the database and creates a new Url object with the UrlId and O properties.
            var images = _context.Urls.Select(u => new Url
            {
                UrlId = u.UrlId,
                O = u.O ?? ""
                //The new object is then added to a list.
            }).ToList();
            //The list is then returned to the view.
            return View(images);
        }
    }
}
