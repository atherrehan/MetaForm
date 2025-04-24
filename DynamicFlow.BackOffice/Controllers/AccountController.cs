using Microsoft.AspNetCore.Mvc;

namespace DynamicFlow.BackOffice.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
