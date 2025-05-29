using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WormBook.Models;
using WormBook.ViewModels;

namespace WormBook.Controllers
{
    public class CatalogosController : Controller
    {
        private readonly MiContexto _context;

        public CatalogosController(MiContexto context)
        {
            _context = context;
        }
        // GET: CatalogosController
        public ActionResult ListaEnvios()
        {
            var envios = (from e in _context.Envios
                          join c in _context.Cliente on e.Telefono equals c.Telefono
                          select new EnvioConClienteVM
                          {
                              Guiaenvio = e.Guiaenvio,
                              Sucursalorigen = e.Sucursalorigen,
                              Destino = e.Destino,
                              Nombre = c.Nombre,
                              Apellido = c.Apellido,
                              Telefono = c.Telefono
                          }).ToList();

            return View(envios); // Enviar como modelo tipado
        }
        public async Task<IActionResult> Libros()
        {
            ViewData["IsLoggedIn"] = User.Identity.IsAuthenticated;
            var libros = await _context.Libros
                .Include(j => j.CodigoInternoNavigation)
                .ThenInclude(p => p.Existencia)
                .ThenInclude(e => e.CodigosucursalNavigation)
                .ToListAsync();



            return View(libros);
        }
        public async Task<IActionResult> ListaProductosEnviados()
        {
            ViewData["IsLoggedIn"] = User.Identity.IsAuthenticated;
            var pe = await _context.Productosenviados
                .Include(j => j.CodigoInternoNavigation)
                .ThenInclude(p => p.Existencia)
                .ThenInclude(e => e.CodigosucursalNavigation)
                .ToListAsync();

            return View(pe);
        }
        public async Task<IActionResult> ListaProductosVendidos()
        {
            ViewData["IsLoggedIn"] = User.Identity.IsAuthenticated;
            var pv = await _context.Productovendidos
                .Include(j => j.CodigoInternoNavigation)
                .ThenInclude(p => p.Existencia)
                .ThenInclude(e => e.CodigosucursalNavigation)
                .ToListAsync();

            return View(pv);
        }
        public async Task<IActionResult> ListaVenta()
        {
            ViewData["IsLoggedIn"] = User.Identity.IsAuthenticated;
            var ventas = await _context.Venta
                .Include(j => j.Productovendidos)
                .ThenInclude(e => e.CodigosucursalNavigation)
                .ToListAsync();



            return View(ventas);
        }
    }
}
