using Microsoft.AspNetCore.Mvc;
using LoginCustom.Data;

namespace LoginCustom.Controllers
{
    public class PrivadoController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public PrivadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
               return View(); 
            }

            HttpContext.Session.SetString("Controlador", "Privado");
            return RedirectToAction("Index", "Login");
        }
    }
}