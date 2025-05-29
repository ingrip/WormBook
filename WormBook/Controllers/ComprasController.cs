using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WormBook.Models;

namespace WormBook.Controllers
{
    public class ComprasController : Controller
    {
        private readonly MiContexto _context;

        public ComprasController(MiContexto context)
        {
            _context = context;
        }
        // GET: ComprasController
        public ActionResult ComprasJuegosMesa()
        {
            var juegos = _context.Juegomesas
       .Include(j => j.CodigointernoNavigation)
           .ThenInclude(c => c.Existencia)
            .ToList();

            var sucursales = _context.Sucursals
                .Select(s => new { Codigo = s.Codigosucursal, Nombre = s.Nombresucursal })
                .ToList();

            ViewBag.Sucursales = sucursales;

            return View(juegos);
        }
        [HttpPost]
        public IActionResult ComprarJuego([FromBody] CompraDto request)
        {
            try
            {
                var existencia = _context.Existencia
                    .FirstOrDefault(e => e.CodigoInterno == request.JuegoId && e.Codigosucursal == request.CodigoSucursal);

                if (existencia == null)
                {
                    return Json(new { success = false, message = "La sucursal o juego no existe." });
                }

                bool esValidacionSolo = Request.Headers.ContainsKey("X-Validation-Only") && Request.Headers["X-Validation-Only"] == "true";

                if (esValidacionSolo)
                {
                    return Json(new
                    {
                        success = existencia.Existencia > 0,
                        message = existencia.Existencia > 0 ? "Stock disponible." : "No hay stock disponible en la sucursal seleccionada."
                    });
                }
                else
                {
                    if (request.Cantidad <= 0)
                        return Json(new { success = false, message = "Cantidad inválida." });

                    if (existencia.Existencia < request.Cantidad)
                        return Json(new { success = false, message = "No hay suficiente stock para la cantidad solicitada." });

                    existencia.Existencia -= request.Cantidad;
                    _context.SaveChanges();


                    var nuevoEnvio = new Envio
                    {
                        Guiaenvio = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssfff")),
                        Numcajas = request.Cantidad,
                        Destino = request.Destino,
                        Sucursalorigen = request.CodigoSucursal,
                        Telefono = request.Telefono
                    };

                    _context.Envios.Add(nuevoEnvio);
                    _context.SaveChanges();
                    var nuevoCliente = new Cliente
                    {
                        Telefono = request.Telefono,
                        Nombre = request.Nombre,
                        Apellido = request.Apellido,
                    };
                    _context.Cliente.Add(nuevoCliente);
                    _context.SaveChanges();
                    return Json(new { success = true, message = "Compra realizada exitosamente y envío registrado." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al procesar la compra: " + ex.Message });
            }
        }
        public ActionResult ComprasLibro()
        {
            var libro = _context.Libros
       .Include(j => j.CodigoInternoNavigation)
           .ThenInclude(c => c.Existencia)
            .ToList();

            var sucursales = _context.Sucursals
                .Select(s => new { Codigo = s.Codigosucursal, Nombre = s.Nombresucursal })
                .ToList();

            ViewBag.Sucursales = sucursales;

            return View(libro);
        }
        [HttpPost]
        public IActionResult ComprarLibro([FromBody] CompraLibro request)
        {
            try
            {
                var existencia = _context.Existencia
                    .FirstOrDefault(e => e.CodigoInterno == request.LibroId && e.Codigosucursal == request.CodigoSucursal);

                if (existencia == null)
                {
                    return Json(new { success = false, message = "La sucursal o libro no existe." });
                }

                bool hayStock = existencia.Existencia > 0;

                bool esValidacionSolo = Request.Headers.ContainsKey("X-Validation-Only") && Request.Headers["X-Validation-Only"] == "true";

                if (esValidacionSolo)
                {
                    return Json(new
                    {
                        success = hayStock,
                        message = hayStock ? "Stock disponible." : "No hay stock disponible en la sucursal seleccionada."
                    });
                }
                else
                {
                    if (request.Cantidad <= 0)
                        return Json(new { success = false, message = "Cantidad inválida." });

                    if (existencia.Existencia < request.Cantidad)
                        return Json(new { success = false, message = "No hay suficiente stock para la cantidad solicitada." });

                    // Reducir stock
                    existencia.Existencia -= request.Cantidad;
                    _context.SaveChanges();

                    var nuevoEnvio = new Envio
                    {
                        Guiaenvio = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssfff")),
                        Numcajas = request.Cantidad,
                        Sucursalorigen = request.CodigoSucursal,
                    };

                    _context.Envios.Add(nuevoEnvio);
                    _context.SaveChanges();

                    var nuevoCliente = new Cliente
                    {
                        Telefono = request.Telefono,
                        Nombre = request.Nombre,
                        Apellido = request.Apellido,
                    };
                    _context.Cliente.Add(nuevoCliente);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Compra realizada exitosamente y envío registrado." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al procesar la compra: " + ex.Message });
            }
        }




        // GET: ComprasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComprasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComprasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComprasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComprasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComprasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
    public class CompraDto
    {
        public int JuegoId { get; set; }
        public int CodigoSucursal { get; set; }
        public int Cantidad { get; set; }
        public string Destino { get; set; }
        public int Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
    public class CompraLibro
    {
        public int LibroId { get; set; }
        public int CodigoSucursal { get; set; }
        public int Cantidad { get; set; }
        public string Destino { get; set; }
        public int Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

}
