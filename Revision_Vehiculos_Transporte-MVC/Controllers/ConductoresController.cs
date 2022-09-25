using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revision_Vehiculos_Transporte_MVC.Models;

namespace Revision_Vehiculos_Transporte_MVC.Controllers
{
    public class ConductoresController : Controller
    {
        private readonly REVIVEHTRANSPContext _context;

        public ConductoresController(REVIVEHTRANSPContext context)
        {
            _context = context;
        }

        // GET: Conductores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conductors.ToListAsync());
        }

        // GET: Conductores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conductors == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conductor == null)
            {
                return NotFound();
            }

            return View(conductor);
        }

        // GET: Conductores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conductores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Direccion,Email,NumeroTelefono,FechaNacimiento,TipoLicencia,NumeroDocumento")] Conductor conductor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conductor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conductor);
        }

        // GET: Conductores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conductors == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductors.FindAsync(id);
            if (conductor == null)
            {
                return NotFound();
            }
            return View(conductor);
        }

        // POST: Conductores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Direccion,Email,NumeroTelefono,FechaNacimiento,TipoLicencia,NumeroDocumento")] Conductor conductor)
        {
            if (id != conductor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conductor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConductorExists(conductor.Id))
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
            return View(conductor);
        }

        // GET: Conductores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conductors == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conductor == null)
            {
                return NotFound();
            }

            return View(conductor);
        }

        // POST: Conductores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conductors == null)
            {
                return Problem("Entity set 'REVIVEHTRANSPContext.Conductors'  is null.");
            }
            var conductor = await _context.Conductors.FindAsync(id);
            if (conductor != null)
            {
                _context.Conductors.Remove(conductor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConductorExists(int id)
        {
            return _context.Conductors.Any(e => e.Id == id);
        }
    }
}
