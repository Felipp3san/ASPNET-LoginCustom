using LoginCustom.Data;
using LoginCustom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginCustom.Controllers
{
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext _context; 

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                var _utilizador = await _context.Utilizadores
                    .FirstOrDefaultAsync(e => e.Username == utilizador.Username && e.Password == utilizador.Password);

                if (_utilizador != null)
                {
                    if (_utilizador.isActive == true)
                    {
                        HttpContext.Session.SetString("Username", _utilizador.Username);
                        HttpContext.Session.SetString("IsAdmin", _utilizador.isAdmin.ToString());
                    }
                    else
                    {
                        return View();
                    }
                }

                return RedirectToAction("Index", HttpContext.Session.GetString("Controlador"));
            } 

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Username", string.Empty);
            HttpContext.Session.SetString("IsAdmin", string.Empty);
            HttpContext.Session.SetString("IsActive", string.Empty);

            return RedirectToAction("Index", "Home");
        }
    }
}