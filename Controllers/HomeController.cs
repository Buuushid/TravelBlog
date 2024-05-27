using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using TravelBlogDB1.Data;
using TravelBlogDB1.Models;

namespace TravelBlogDB1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IGalleryItemRepository _galleryItemRepository;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IGalleryItemRepository galleryItemRepository)
        {
            _logger = logger;
            _context = context;
            _galleryItemRepository = galleryItemRepository;
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

        public async Task<IActionResult> Gallery()
        {
            var galleryItems = await _galleryItemRepository.GetAllAsync();
            return View(galleryItems);
        }


        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Email email)
        {
            if (ModelState.IsValid)
            {
                _context.Emails.Add(email);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Formularz zosta³ wys³any poprawnie. Nied³ugo odpowiemy.";
                ModelState.Clear();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
