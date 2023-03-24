using BotaniFinder.Context;
using BotaniFinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace BotaniFinder.Controllers
{

    public class PreviousIdentificationsFromDatabaseController : Controller
    {
        private readonly BotaniFinderDbContext _context;

        public PreviousIdentificationsFromDatabaseController(BotaniFinderDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var images = _context.Urls.Select(u => new Url
            {
                UrlId = u.UrlId,
                O = u.O ?? ""
            }).ToList();
            return View(images);
        }
    }
}
