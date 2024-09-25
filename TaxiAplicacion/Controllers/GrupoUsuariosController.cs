using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TaxiAplicacion.Controllers
{
    public class GrupoUsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GrupoUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GrupoUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.GruposUsuarios.ToListAsync());
        }

        // GET: GrupoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoUsuarios = await _context.GruposUsuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoUsuarios == null)
            {
                return NotFound();
            }

            return View(grupoUsuarios);
        }

        // GET: GrupoUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreGrupo")] GrupoUsuarios grupoUsuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoUsuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupoUsuarios);
        }

        // GET: GrupoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoUsuarios = await _context.GruposUsuarios.FindAsync(id);
            if (grupoUsuarios == null)
            {
                return NotFound();
            }
            return View(grupoUsuarios);
        }

        // POST: GrupoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreGrupo")] GrupoUsuarios grupoUsuarios)
        {
            if (id != grupoUsuarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoUsuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoUsuariosExists(grupoUsuarios.Id))
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
            return View(grupoUsuarios);
        }

        // GET: GrupoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoUsuarios = await _context.GruposUsuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoUsuarios == null)
            {
                return NotFound();
            }

            return View(grupoUsuarios);
        }

        // POST: GrupoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoUsuarios = await _context.GruposUsuarios.FindAsync(id);
            if (grupoUsuarios != null)
            {
                _context.GruposUsuarios.Remove(grupoUsuarios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoUsuariosExists(int id)
        {
            return _context.GruposUsuarios.Any(e => e.Id == id);
        }
    }
}
