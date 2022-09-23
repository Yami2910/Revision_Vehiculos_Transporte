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
    public class VehiculosController : Controller
    {
        private readonly REVIVEHTRANSPContext _context;

        public VehiculosController(REVIVEHTRANSPContext context)
        {
            _context = context;
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index()
        {
            var rEVIVEHTRANSPContext = _context.Vehiculos.Include(v => v.IdConductorNavigation).Include(v => v.IdDuenoVehiculoNavigation);
            return View(await rEVIVEHTRANSPContext.ToListAsync());
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.IdConductorNavigation)
                .Include(v => v.IdDuenoVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            ViewData["IdConductor"] = new SelectList(_context.Conductors, "Id", "Id");
            ViewData["IdDuenoVehiculo"] = new SelectList(_context.DuenoVehiculos, "Id", "Id");
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,Tipo,Marca,Modelo,CapacidadPasajeros,CilindrajeMotor,PaisOrigen,DescripcionGeneral,OtrasCaracteristicas,IdDuenoVehiculo,IdConductor")] Vehiculo vehiculo)
        {
            if (vehiculo!=null)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConductor"] = new SelectList(_context.Conductors, "Id", "Id", vehiculo.IdConductor);
            ViewData["IdDuenoVehiculo"] = new SelectList(_context.DuenoVehiculos, "Id", "Id", vehiculo.IdDuenoVehiculo);
            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            ViewData["IdConductor"] = new SelectList(_context.Conductors, "Id", "Id", vehiculo.IdConductor);
            ViewData["IdDuenoVehiculo"] = new SelectList(_context.DuenoVehiculos, "Id", "Id", vehiculo.IdDuenoVehiculo);
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,Tipo,Marca,Modelo,CapacidadPasajeros,CilindrajeMotor,PaisOrigen,DescripcionGeneral,OtrasCaracteristicas,IdDuenoVehiculo,IdConductor")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (vehiculo!=null)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Id))
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
            ViewData["IdConductor"] = new SelectList(_context.Conductors, "Id", "Id", vehiculo.IdConductor);
            ViewData["IdDuenoVehiculo"] = new SelectList(_context.DuenoVehiculos, "Id", "Id", vehiculo.IdDuenoVehiculo);
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.IdConductorNavigation)
                .Include(v => v.IdDuenoVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehiculos == null)
            {
                return Problem("Entity set 'REVIVEHTRANSPContext.Vehiculos'  is null.");
            }
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
          return _context.Vehiculos.Any(e => e.Id == id);
        }
    }
}
