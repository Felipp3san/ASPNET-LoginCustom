using LoginCustom.Data;
using Microsoft.AspNetCore.Mvc;

namespace LoginCustom.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _context; 

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username"))
            && Convert.ToBoolean(HttpContext.Session.GetString("IsAdmin")) == true)
            {
               return View(); 
            }
            else if(!string.IsNullOrEmpty(HttpContext.Session.GetString("Username"))
            && Convert.ToBoolean(HttpContext.Session.GetString("IsAdmin")) == false)
            {
                return RedirectToAction("AcessoNegado");
            }

            HttpContext.Session.SetString("Controlador", "Admin");
            return RedirectToAction("Index", "Login");
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }

    }
}