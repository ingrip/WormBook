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
        [HttpPost]
        public async Task<IActionResult> BuscarPorTelefono(string telefono)
        {
            if (!long.TryParse(telefono, out long telefonoLong))
            {
                return Json(new { success = false, message = "Número de teléfono inválido." });
            }

            // Buscar cliente
            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(c => c.Telefono == telefonoLong);

            if (cliente == null)
            {
                return Json(new { success = false, message = "Cliente no encontrado." });
            }

            // Buscar envíos relacionados por teléfono
            var envios = await (from e in _context.Envios
                                join s in _context.Sucursals
                                on e.Sucursalorigen equals s.Codigosucursal
                                where e.Telefono == telefonoLong
                                select new
                                {
                                    e.Guiaenvio,
                                    e.Destino,
                                    SucursalOrigenNombre = s.Nombresucursal
                                }).ToListAsync();

            return Json(new
            {
                success = true,
                cliente = new
                {
                    cliente.Nombre,
                    cliente.Apellido,
                    cliente.Telefono
                },
                envios
            });
        }

    }
}
