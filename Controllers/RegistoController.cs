using Microsoft.AspNetCore.Mvc;
using LoginCustom.Data;
using LoginCustom.Models;

namespace LoginCustom.Controllers
{
    public class RegistoController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public RegistoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Utilizador utilizador, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                if (utilizador.Password.Equals(confirmPassword))
                {
                    _context.Add(utilizador); 
                    await _context.SaveChangesAsync();

                    HttpContext.Session.SetString("Controlador", "Home");

                    return RedirectToAction("Index", "Login"); 
                }
                else
                {
                    ViewData["Mensagem"] = "Passwords não conferem.";
                }
            }

            HttpContext.Session.SetString("Controlador", "Home");

            return View();
        } 
    }
}