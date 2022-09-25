using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revision_Vehiculos_Transporte_MVC.Models;

namespace Revision_Vehiculos_Transporte_MVC.Controllers
{
    public class DuenosVehiculosController : Controller
    {
        private readonly REVIVEHTRANSPContext _context;

        public DuenosVehiculosController(REVIVEHTRANSPContext context)
        {
            _context = context;
        }

        // GET: DuenosVehiculos
        public async Task<IActionResult> Index()
        {
            return View(await _context.DuenoVehiculos.ToListAsync());
        }

        // GET: DuenosVehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DuenoVehiculos == null)
            {
                return NotFound();
            }

            var duenoVehiculo = await _context.DuenoVehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duenoVehiculo == null)
            {
                return NotFound();
            }

            return View(duenoVehiculo);
        }

        // GET: DuenosVehiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DuenosVehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Direccion,Email,NumeroTelefono,FechaNacimiento,CiudadResidencia,NumeroDocumento")] DuenoVehiculo duenoVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duenoVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duenoVehiculo);
        }

        // GET: DuenosVehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DuenoVehiculos == null)
            {
                return NotFound();
            }

            var duenoVehiculo = await _context.DuenoVehiculos.FindAsync(id);
            if (duenoVehiculo == null)
            {
                return NotFound();
            }
            return View(duenoVehiculo);
        }

        // POST: DuenosVehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Direccion,Email,NumeroTelefono,FechaNacimiento,CiudadResidencia,NumeroDocumento")] DuenoVehiculo duenoVehiculo)
        {
            if (id != duenoVehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duenoVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuenoVehiculoExists(duenoVehiculo.Id))
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
            return View(duenoVehiculo);
        }

        // GET: DuenosVehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DuenoVehiculos == null)
            {
                return NotFound();
            }

            var duenoVehiculo = await _context.DuenoVehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duenoVehiculo == null)
            {
                return NotFound();
            }

            return View(duenoVehiculo);
        }

        // POST: DuenosVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DuenoVehiculos == null)
            {
                return Problem("Entity set 'REVIVEHTRANSPContext.DuenoVehiculos'  is null.");
            }
            var duenoVehiculo = await _context.DuenoVehiculos.FindAsync(id);
            if (duenoVehiculo != null)
            {
                _context.DuenoVehiculos.Remove(duenoVehiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuenoVehiculoExists(int id)
        {
            return _context.DuenoVehiculos.Any(e => e.Id == id);
        }
    }
}
