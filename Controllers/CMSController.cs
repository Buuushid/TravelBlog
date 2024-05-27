using Microsoft.AspNetCore.Mvc;

namespace TravelBlogDB1.Controllers
{
    public class CMSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
