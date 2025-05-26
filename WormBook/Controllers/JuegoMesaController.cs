using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WormBook.Models;  // Ajusta el namespace de MiContexto y modelo JuegoMesa si es necesario

namespace WormBook.Controllers
{
    public class JuegoMesaController : Controller
    {
        private readonly MiContexto _context;

        public JuegoMesaController(MiContexto context)
        {
            _context = context;
        }

        // GET: /JuegoMesa
        public async Task<IActionResult> JuegoMesa()
        {
            var juegos = await _context.Juegomesas
                .Include(j => j.CodigoInternoNavigation)    // Cargar el Producto
                .ThenInclude(p => p.Existencia)             // Incluir las Existencias del Producto
                .ThenInclude(e => e.CodigosucursalNavigation) // Incluir las sucursales asociadas a las Existenci
                                                              // as
                .ToListAsync();

            return View(juegos);
        }



    }
}
