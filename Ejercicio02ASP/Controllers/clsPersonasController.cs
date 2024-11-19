using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ENT;
using Ejercicio02ASP.Data;

namespace Ejercicio02ASP.Controllers
{
    public class clsPersonasController : Controller
    {
        private readonly Ejercicio02ASPContext _context;

        public clsPersonasController(Ejercicio02ASPContext context)
        {
            _context = context;
        }

        // GET: clsPersonas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personas.ToListAsync());
        }

        // GET: clsPersonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsPersona = await _context.Personas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clsPersona == null)
            {
                return NotFound();
            }

            return View(clsPersona);
        }

        // GET: clsPersonas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: clsPersonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos,Telefono,Direccion,Foto,FechaNacimiento,IdDepartamento")] clsPersona clsPersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clsPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clsPersona);
        }

        // GET: clsPersonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsPersona = await _context.Personas.FindAsync(id);
            if (clsPersona == null)
            {
                return NotFound();
            }
            return View(clsPersona);
        }

        // POST: clsPersonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellidos,Telefono,Direccion,Foto,FechaNacimiento,IdDepartamento")] clsPersona clsPersona)
        {
            if (id != clsPersona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clsPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!clsPersonaExists(clsPersona.Id))
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
            return View(clsPersona);
        }

        // GET: clsPersonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsPersona = await _context.Personas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clsPersona == null)
            {
                return NotFound();
            }

            return View(clsPersona);
        }

        // POST: clsPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clsPersona = await _context.Personas.FindAsync(id);
            if (clsPersona != null)
            {
                _context.Personas.Remove(clsPersona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool clsPersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}
