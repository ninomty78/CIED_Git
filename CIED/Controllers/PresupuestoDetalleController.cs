using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIED.Models;

namespace CIED.Controllers
{
    public class PresupuestoDetalleController : Controller
    {
        private readonly CIEDContext _context;

        public PresupuestoDetalleController(CIEDContext context)
        {
            _context = context;
        }

        // GET: PresupuestoDetalle
        public async Task<IActionResult> Index()
        {
            var cIEDContext = _context.PresupuestoDetalle.Include(p => p.Categoria).Include(p => p.Presupuesto);
            return View(await cIEDContext.ToListAsync());
        }

        // GET: PresupuestoDetalle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoDetalle = await _context.PresupuestoDetalle
                .Include(p => p.Categoria)
                .Include(p => p.Presupuesto)
                .FirstOrDefaultAsync(m => m.PresupuestoDetalleID == id);
            if (presupuestoDetalle == null)
            {
                return NotFound();
            }

            return View(presupuestoDetalle);
        }

        // GET: PresupuestoDetalle/Create
        public IActionResult Create()
        {
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "Descripcion");
            ViewData["PresupuestoID"] = new SelectList(_context.Presupuesto, "PresupuestoID", "Descripcion");
            return View();
        }

        // POST: PresupuestoDetalle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PresupuestoDetalleID,PresupuestoID,CategoriaID,Partida")] PresupuestoDetalle presupuestoDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presupuestoDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "Descripcion", presupuestoDetalle.CategoriaID);
            ViewData["PresupuestoID"] = new SelectList(_context.Presupuesto, "PresupuestoID", "Descripcion", presupuestoDetalle.PresupuestoID);
            return View(presupuestoDetalle);
        }

        // GET: PresupuestoDetalle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoDetalle = await _context.PresupuestoDetalle.FindAsync(id);
            if (presupuestoDetalle == null)
            {
                return NotFound();
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "Descripcion", presupuestoDetalle.CategoriaID);
            ViewData["PresupuestoID"] = new SelectList(_context.Presupuesto, "PresupuestoID", "Descripcion", presupuestoDetalle.PresupuestoID);
            return View(presupuestoDetalle);
        }

        // POST: PresupuestoDetalle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PresupuestoDetalleID,PresupuestoID,CategoriaID,Partida")] PresupuestoDetalle presupuestoDetalle)
        {
            if (id != presupuestoDetalle.PresupuestoDetalleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presupuestoDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresupuestoDetalleExists(presupuestoDetalle.PresupuestoDetalleID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "Descripcion", presupuestoDetalle.CategoriaID);
            ViewData["PresupuestoID"] = new SelectList(_context.Presupuesto, "PresupuestoID", "Descripcion", presupuestoDetalle.PresupuestoID);
            return View(presupuestoDetalle);
        }

        // GET: PresupuestoDetalle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoDetalle = await _context.PresupuestoDetalle
                .Include(p => p.Categoria)
                .Include(p => p.Presupuesto)
                .FirstOrDefaultAsync(m => m.PresupuestoDetalleID == id);
            if (presupuestoDetalle == null)
            {
                return NotFound();
            }

            return View(presupuestoDetalle);
        }

        // POST: PresupuestoDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presupuestoDetalle = await _context.PresupuestoDetalle.FindAsync(id);
            _context.PresupuestoDetalle.Remove(presupuestoDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresupuestoDetalleExists(int id)
        {
            return _context.PresupuestoDetalle.Any(e => e.PresupuestoDetalleID == id);
        }
    }
}
