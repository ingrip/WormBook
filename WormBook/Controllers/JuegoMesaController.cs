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
        public async Task<IActionResult> JuegoMesa()
        {
            var juegos = await _context.Juegomesas
                .Include(j => j.CodigointernoNavigation)
                .ThenInclude(p => p.Existencia)
                .ThenInclude(e => e.CodigosucursalNavigation)
                .ToListAsync();

          

            return View(juegos);
        }
        [HttpGet]
        [HttpGet]
        public IActionResult GetSucursalesYExistencias(int juegoId)
        {
            var juego = _context.Juegomesas
                .Include(j => j.CodigointernoNavigation.Existencia)
                .ThenInclude(e => e.CodigosucursalNavigation)
                .FirstOrDefault(j => j.Codigointerno == juegoId);

            if (juego == null)
            {
                return NotFound();
            }

            var sucursales = juego.CodigointernoNavigation.Existencia
                .Select(e => new
                {
                    e.Codigosucursal,
                    e.CodigosucursalNavigation.Nombresucursal
                }).ToList();

            var existencias = juego.CodigointernoNavigation.Existencia
                .Select(e => new
                {
                    e.Codigosucursal,
                    e.Existencia,
                    e.CodigosucursalNavigation.Nombresucursal
                }).ToList();

            return Json(new { sucursales = sucursales, existencias = existencias });
        }


    }
}
