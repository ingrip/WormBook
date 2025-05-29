using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> JuegoMesa()
        {
            ViewData["IsLoggedIn"] = User.Identity.IsAuthenticated;
            var juegos = await _context.Juegomesas
                .Include(j => j.CodigointernoNavigation)
                .ThenInclude(p => p.Existencia)
                .ThenInclude(e => e.CodigosucursalNavigation)
                .ToListAsync();

          

            return View(juegos);
        }
        [HttpPost]
        public JsonResult GetSucursalesYExistencias(int juegoId)
        {
            var existencias = _context.Existencia
                .Where(e => e.CodigoInterno == juegoId)
                .Select(e => new {
                    Codigosucursal = e.Codigosucursal,
                    Existencia = e.Existencia,
                    Nombresucursal = e.CodigosucursalNavigation.Nombresucursal,
                })
                .ToList();



            return Json(new { existencias });
        }

        [HttpPost]
        public IActionResult GuardarExistencias([FromBody] SucursalExistenciaDto request)
        {
            try
            {
                var existencia = _context.Existencia
                    .FirstOrDefault(e => e.CodigoInterno == request.JuegoId && e.Codigosucursal == request.CodigoSucursal);

                if (existencia != null)
                {
                    existencia.Existencia = request.Existencia;
                }
                else
                {
                    _context.Existencia.Add(new Existencium
                    {
                        CodigoInterno = request.JuegoId,
                        Codigosucursal = request.CodigoSucursal,
                        Existencia = request.Existencia
                    });
                }

                _context.SaveChanges();
                return Json(new { success = true, message = "Existencia guardada correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al guardar existencia: " + ex.Message });
            }
        }

        public class SucursalExistenciaDto
        {
            public int JuegoId { get; set; }
            public int CodigoSucursal { get; set; }
            public int Existencia { get; set; }
        }


    }
}
