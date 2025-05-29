using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WormBook.Models;

namespace WormBook.Controllers
{
    public class VentasController : Controller
    {
        private readonly MiContexto _context;

        public VentasController(MiContexto context)
        {
            _context = context;
        }
        public async Task<IActionResult> Ventas()
        {
            return View();
        }
    }
}
