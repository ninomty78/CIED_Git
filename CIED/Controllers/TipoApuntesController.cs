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
    public class TipoApuntesController : Controller
    {
        private readonly CIEDContext _context;

        public TipoApuntesController(CIEDContext context)
        {
            _context = context;
        }

        // GET: TipoApuntes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoApunte.ToListAsync());
        }

        // GET: TipoApuntes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoApunte = await _context.TipoApunte
                .FirstOrDefaultAsync(m => m.TipoApunteID == id);
            if (tipoApunte == null)
            {
                return NotFound();
            }

            return View(tipoApunte);
        }

        // GET: TipoApuntes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoApuntes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoApunteID,Descripcion,Egreso,Estatus")] TipoApunte tipoApunte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoApunte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoApunte);
        }

        // GET: TipoApuntes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoApunte = await _context.TipoApunte.FindAsync(id);
            if (tipoApunte == null)
            {
                return NotFound();
            }
            return View(tipoApunte);
        }

        // POST: TipoApuntes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoApunteID,Descripcion,Egreso,Estatus")] TipoApunte tipoApunte)
        {
            if (id != tipoApunte.TipoApunteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoApunte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoApunteExists(tipoApunte.TipoApunteID))
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
            return View(tipoApunte);
        }

        // GET: TipoApuntes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoApunte = await _context.TipoApunte
                .FirstOrDefaultAsync(m => m.TipoApunteID == id);
            if (tipoApunte == null)
            {
                return NotFound();
            }

            return View(tipoApunte);
        }

        // POST: TipoApuntes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoApunte = await _context.TipoApunte.FindAsync(id);
            _context.TipoApunte.Remove(tipoApunte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoApunteExists(int id)
        {
            return _context.TipoApunte.Any(e => e.TipoApunteID == id);
        }
    }
}
