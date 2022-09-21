using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Revision_Vehiculos_Transporte_MVC.Models;

namespace Revision_Vehiculos_Transporte_MVC.Controllers
{
    public class MecanicosController : Controller
    {
        private readonly REVIVEHTRANSPContext _context;

        public MecanicosController(REVIVEHTRANSPContext context)
        {
            _context = context;
        }

        // GET: Mecanicos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Mecanicos.ToListAsync());
        }

        // GET: Mecanicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mecanicos == null)
            {
                return NotFound();
            }

            var mecanico = await _context.Mecanicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mecanico == null)
            {
                return NotFound();
            }

            return View(mecanico);
        }

        // GET: Mecanicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mecanicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Direccion,Email,NumeroTelefono,FechaNacimiento,NivelEstudios,NumeroDocumento")] Mecanico mecanico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mecanico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mecanico);
        }

        // GET: Mecanicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mecanicos == null)
            {
                return NotFound();
            }

            var mecanico = await _context.Mecanicos.FindAsync(id);
            if (mecanico == null)
            {
                return NotFound();
            }
            return View(mecanico);
        }

        // POST: Mecanicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Direccion,Email,NumeroTelefono,FechaNacimiento,NivelEstudios,NumeroDocumento")] Mecanico mecanico)
        {
            if (id != mecanico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mecanico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MecanicoExists(mecanico.Id))
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
            return View(mecanico);
        }

        // GET: Mecanicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mecanicos == null)
            {
                return NotFound();
            }

            var mecanico = await _context.Mecanicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mecanico == null)
            {
                return NotFound();
            }

            return View(mecanico);
        }

        // POST: Mecanicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mecanicos == null)
            {
                return Problem("Entity set 'REVIVEHTRANSPContext.Mecanicos'  is null.");
            }
            var mecanico = await _context.Mecanicos.FindAsync(id);
            if (mecanico != null)
            {
                _context.Mecanicos.Remove(mecanico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MecanicoExists(int id)
        {
          return _context.Mecanicos.Any(e => e.Id == id);
        }
    }
}
