using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }
    }
}
