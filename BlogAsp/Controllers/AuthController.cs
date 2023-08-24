using BlogAsp.Data;
using BlogAsp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BlogAsp.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AuthController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Check(User user_)
        {
            Console.WriteLine("Checking input data");
            var users = await _context.Users.ToListAsync();

            foreach (var user in users)
            {
                if (user.Email == user_.Email && user.Password == user_.Password)
                {
                    Console.WriteLine("Logged IN!");
                    Console.WriteLine(user.Name);

                    LoggedInUser.Email = user.Email;
                    LoggedInUser.Password = user.Password;
                    LoggedInUser.UserName = user.Name;
                    LoggedInUser.IsLoggedIn = true;
                    LoggedInUser.isAdmin = user.isAdmin;




                    Console.WriteLine("LoggedInUserName: " + LoggedInUser.UserName);
                    Console.WriteLine("LoggedInUser.isAdmin: " + LoggedInUser.isAdmin);

                    return Redirect("/");
                }
            }

            return View();
        }

        // GET: AuthController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser([Bind("Id,Name,Email,Password,isAdmin")] User user)
        {

            Console.WriteLine($"user.id: {user.Id}");
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
