using Microsoft.AspNetCore.Mvc;

namespace LabAPI.Controllers
{
    public class ImagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
