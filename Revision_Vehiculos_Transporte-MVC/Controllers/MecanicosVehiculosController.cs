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
    public class MecanicosVehiculosController : Controller
    {
        private readonly REVIVEHTRANSPContext _context;

        public MecanicosVehiculosController(REVIVEHTRANSPContext context)
        {
            _context = context;
        }

        // GET: MecanicosVehiculos
        public async Task<IActionResult> Index()
        {
            var rEVIVEHTRANSPContext = _context.MecanicoVehiculos.Include(m => m.IdMecanicoNavigation).Include(m => m.IdVehiculoNavigation);
            return View(await rEVIVEHTRANSPContext.ToListAsync());
        }

        // GET: MecanicosVehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MecanicoVehiculos == null)
            {
                return NotFound();
            }

            var mecanicoVehiculo = await _context.MecanicoVehiculos
                .Include(m => m.IdMecanicoNavigation)
                .Include(m => m.IdVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mecanicoVehiculo == null)
            {
                return NotFound();
            }

            return View(mecanicoVehiculo);
        }

        // GET: MecanicosVehiculos/Create
        public IActionResult Create()
        {
            ViewData["IdMecanico"] = new SelectList(_context.Mecanicos, "Id", "Id");
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Id");
            return View();
        }

        // POST: MecanicosVehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdMecanico,IdVehiculo")] MecanicoVehiculo mecanicoVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mecanicoVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMecanico"] = new SelectList(_context.Mecanicos, "Id", "Id", mecanicoVehiculo.IdMecanico);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Id", mecanicoVehiculo.IdVehiculo);
            return View(mecanicoVehiculo);
        }

        // GET: MecanicosVehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MecanicoVehiculos == null)
            {
                return NotFound();
            }

            var mecanicoVehiculo = await _context.MecanicoVehiculos.FindAsync(id);
            if (mecanicoVehiculo == null)
            {
                return NotFound();
            }
            ViewData["IdMecanico"] = new SelectList(_context.Mecanicos, "Id", "Id", mecanicoVehiculo.IdMecanico);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Id", mecanicoVehiculo.IdVehiculo);
            return View(mecanicoVehiculo);
        }

        // POST: MecanicosVehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdMecanico,IdVehiculo")] MecanicoVehiculo mecanicoVehiculo)
        {
            if (id != mecanicoVehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mecanicoVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MecanicoVehiculoExists(mecanicoVehiculo.Id))
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
            ViewData["IdMecanico"] = new SelectList(_context.Mecanicos, "Id", "Id", mecanicoVehiculo.IdMecanico);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Id", mecanicoVehiculo.IdVehiculo);
            return View(mecanicoVehiculo);
        }

        // GET: MecanicosVehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MecanicoVehiculos == null)
            {
                return NotFound();
            }

            var mecanicoVehiculo = await _context.MecanicoVehiculos
                .Include(m => m.IdMecanicoNavigation)
                .Include(m => m.IdVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mecanicoVehiculo == null)
            {
                return NotFound();
            }

            return View(mecanicoVehiculo);
        }

        // POST: MecanicosVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MecanicoVehiculos == null)
            {
                return Problem("Entity set 'REVIVEHTRANSPContext.MecanicoVehiculos'  is null.");
            }
            var mecanicoVehiculo = await _context.MecanicoVehiculos.FindAsync(id);
            if (mecanicoVehiculo != null)
            {
                _context.MecanicoVehiculos.Remove(mecanicoVehiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MecanicoVehiculoExists(int id)
        {
          return _context.MecanicoVehiculos.Any(e => e.Id == id);
        }
    }
}
