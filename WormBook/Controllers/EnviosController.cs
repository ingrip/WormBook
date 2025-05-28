using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WormBook.Models; 

namespace WormBook.Controllers
{
    public class EnviosController : Controller
    {
        private readonly MiContexto _context;

        public EnviosController(MiContexto context)
        {
            _context = context;
        }
        public async Task<IActionResult> Envios()
        {
            return View();
        }
    }
}
