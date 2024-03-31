using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    public class TheatersController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }



    }
}
