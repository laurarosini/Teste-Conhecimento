using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teste_K2iP.Data;
using Teste_K2iP.Models;

namespace Teste_K2iP.Controllers
{
    public class AdquirentesController : Controller
    {
        private readonly BancoContext _context;

        public AdquirentesController(BancoContext context)
        {
            _context = context;
        }

        // GET: Adquirentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adquirente.ToListAsync());
        }

        // GET: Adquirentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adquirente = await _context.Adquirente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adquirente == null)
            {
                return NotFound();
            }

            return View(adquirente);
        }

        // GET: Adquirentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adquirentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Descricao")] Adquirente adquirente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adquirente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adquirente);
        }

        // GET: Adquirentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adquirente = await _context.Adquirente.FindAsync(id);
            if (adquirente == null)
            {
                return NotFound();
            }
            return View(adquirente);
        }

        // POST: Adquirentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Descricao")] Adquirente adquirente)
        {
            if (id != adquirente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adquirente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdquirenteExists(adquirente.Id))
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
            return View(adquirente);
        }

        // GET: Adquirentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adquirente = await _context.Adquirente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adquirente == null)
            {
                return NotFound();
            }

            return View(adquirente);
        }

        // POST: Adquirentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adquirente = await _context.Adquirente.FindAsync(id);
            _context.Adquirente.Remove(adquirente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdquirenteExists(int id)
        {
            return _context.Adquirente.Any(e => e.Id == id);
        }
    }
}
