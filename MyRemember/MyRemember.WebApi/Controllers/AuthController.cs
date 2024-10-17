using Microsoft.AspNetCore.Mvc;

namespace MyRemember.WebApi.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
