using BlogAsp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAsp.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Log_out() {
            LoggedInUser.ClearCredentials();
            return Redirect("/");
        }
    }
}
