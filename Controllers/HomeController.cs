using Microsoft.AspNetCore.Mvc;
using TravelBlog.Data;
using TravelBlog.Models;
using System.Threading.Tasks;

namespace TravelBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            var galleryItems = _context.GalleryItems.ToList();
            return View(galleryItems);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitContactForm(Email model)
        {
            if (ModelState.IsValid)
            {
                _context.Emails.Add(model);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Formularz zosta³ wys³any poprawnie.";
                return View("Contact");
            }

            return View("Contact", model);
        }
    }
}
