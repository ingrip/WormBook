using Microsoft.AspNetCore.Mvc;
using WormBook.Models;
using System.Linq;
using System;

namespace WormBook.Controllers
{
    public class LoginController : Controller
    {
        private readonly MiContexto _context;

        public LoginController(MiContexto context)
        {
            _context = context;
        }

        // GET: /Login/Login
        [HttpGet]
        public IActionResult Login() => View();

        // POST: /Login/Login
        [HttpPost]
        public IActionResult Login(Login model)
        {
            var user = _context.Logins
                .FirstOrDefault(u => u.email == model.email && u.password == model.password);

            if (user != null)
            {
                // Guardar sesión
                HttpContext.Session.SetString("user", user.email);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email o contraseña incorrectos.");
            return View(model);
        }


        // GET: /Login/Register
        [HttpGet]
        public IActionResult Register() => View();

        // POST: /Login/Register
        [HttpPost]
        public IActionResult RegisterRegistro(Login model)
        {
            var exists = _context.Logins
            .AsEnumerable()
            .Any(u => u.email == model.email);

            if (exists)
            {
                ModelState.AddModelError("email", "El correo ya está registrado.");
                return View(model);
            }

            _context.Logins.Add(model);
            _context.SaveChanges();

            TempData["Message"] = "Usuario registrado exitosamente. Ahora inicia sesión";
            return RedirectToAction("Login", "Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();  // Limpiar sesión
            return RedirectToAction("Login", "Login"); // Redirigir a Login
        }

    }
}
