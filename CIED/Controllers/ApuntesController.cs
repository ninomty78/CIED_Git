using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIED.Models;
using CIED.Controllers.Interfaces;
using CIED.Controllers.Common;
using CIED.Controllers.Util;

namespace CIED.Controllers
{


    public class ApuntesController : Controller
    {
        private readonly CIEDContext _context;

        public ApuntesController(CIEDContext context)
        {
            _context = context;
        }

      

        private void createList(ICreateList li)
        {
            var list = new CreateList(li);
            list.LoadList(_context, this);           
        }

        private  void createLists()
        {
            //Llenamos los combos de las pantallas
            var liTipoAunte =  new CreateListTipoApunte();
            var liEmpresa = new CreateListEmpresa();
            var liSlot = new CreateListSlot();
            createList(liTipoAunte);
            createList(liEmpresa);
            createList(liSlot);
        }

   


        // GET: Apuntes
        public async Task<IActionResult> Index()
        {
            ViewBag.ActivoInicio = "active";
            ViewBag.ActivoAgregar = "";

            var vSlot1 = await _context.Slot
               .FirstOrDefaultAsync(m => m.Identificador == 1);
            if (vSlot1 != null)
            {
                ViewBag.slot1_desc = vSlot1.Descripcion;
                ViewBag.slot1_importe = vSlot1.Importe;
            }
            else
            {
                ViewBag.slot1_desc = "Slot1";
                ViewBag.slot1_importe = 0;
            }

            var vSlot2 = await _context.Slot
               .FirstOrDefaultAsync(m => m.Identificador == 2);
            if (vSlot2 != null)
            {
                ViewBag.slot2_desc = vSlot2.Descripcion;
                ViewBag.slot2_importe = vSlot2.Importe;
            }
            else
            {
                ViewBag.slot2_desc = "Slot2";
                ViewBag.slot2_importe = 0;
            }


            var vSlot3 = await _context.Slot
               .FirstOrDefaultAsync(m => m.Identificador == 3);
            if (vSlot3 != null)
            {
                ViewBag.slot3_desc = vSlot3.Descripcion;
                ViewBag.slot3_importe = vSlot3.Importe;
            }
            else
            {
                ViewBag.slot3_desc = "Slot3";
                ViewBag.slot3_importe = 0;
            }

            var vSlot4 = await _context.Slot
               .FirstOrDefaultAsync(m => m.Identificador == 4);
            if (vSlot4 != null)
            {
                ViewBag.slot4_desc = vSlot4.Descripcion;
                ViewBag.slot4_importe = vSlot4.Importe;
            }
            else
            {
                ViewBag.slot4_desc = "Slot4";
                ViewBag.slot4_importe = 0;
            }

            var vSlot5 = await _context.Slot
               .FirstOrDefaultAsync(m => m.Identificador == 5);
            if (vSlot5 != null)
            {
                ViewBag.slot5_desc = vSlot5.Descripcion;
                ViewBag.slot5_importe = vSlot5.Importe;
            }
            else
            {
                ViewBag.slot5_desc = "Slot5";
                ViewBag.slot5_importe = 0;
            }

            var vSlot6 = await _context.Slot
              .FirstOrDefaultAsync(m => m.Identificador == 6);
            if (vSlot6 != null)
            {
                ViewBag.slot6_desc = vSlot6.Descripcion;
                ViewBag.slot6_importe = vSlot6.Importe;
            }
            else
            {
                ViewBag.slot6_desc = "Slot6";
                ViewBag.slot6_importe = 0;
            }

            var vSlot7 = await _context.Slot
              .FirstOrDefaultAsync(m => m.Identificador == 7);
            if (vSlot7 != null)
            {
                ViewBag.slot7_desc = vSlot7.Descripcion;
                ViewBag.slot7_importe = vSlot7.Importe;
            }
            else
            {
                ViewBag.slot7_desc = "Slot7";
                ViewBag.slot7_importe = 0;
            }

            
            return View(await _context.Apunte.Include("TipoApunte").Include("Empresa").ToListAsync());
        }

        // GET: Apuntes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apunte = await _context.Apunte
                .FirstOrDefaultAsync(m => m.ApunteID == id);
            if (apunte == null)
            {
                return NotFound();
            }

            
            createLists();

            return View(apunte);
        }

        // GET: Apuntes/Create
        public IActionResult Create()
        { 

            ViewBag.ActivoInicio="";
            ViewBag.ActivoAgregar="active";

            createLists();

            return View();
        }

        // POST: Apuntes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApunteID,Descripcion,Importe,Fecha,Estatus,TipoApunteID,EmpresaID,SlotID")] Apunte apunte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apunte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apunte);
        }

        // GET: Apuntes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apunte = await _context.Apunte.FindAsync(id);
            if (apunte == null)
            {
                return NotFound();
            }


            createLists();

            return View(apunte);
        }

        // POST: Apuntes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApunteID,Descripcion,Importe,Fecha,Estatus,TipoApunteID")] Apunte apunte)
        {
            if (id != apunte.ApunteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apunte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApunteExists(apunte.ApunteID))
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
            return View(apunte);
        }

        // GET: Apuntes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apunte = await _context.Apunte
                .FirstOrDefaultAsync(m => m.ApunteID == id);
            if (apunte == null)
            {
                return NotFound();
            }

            createLists();

            return View(apunte);
        }

        // POST: Apuntes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apunte = await _context.Apunte.FindAsync(id);
            _context.Apunte.Remove(apunte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApunteExists(int id)
        {
            return _context.Apunte.Any(e => e.ApunteID == id);
        }
    }
}
