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

                if (existencia == null || existencia.Existencia <= 0)
                {
                    return Json(new { success = false, message = "No hay suficiente stock en la sucursal seleccionada." });
                }

                existencia.Existencia -= 1;
                _context.SaveChanges();

                return Json(new { success = true, message = "Compra realizada exitosamente." });
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
    }

}
