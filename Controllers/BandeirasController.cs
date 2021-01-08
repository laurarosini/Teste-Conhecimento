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
    public class BandeirasController : Controller
    {
        private readonly BancoContext _context;

        public BandeirasController(BancoContext context)
        {
            _context = context;
        }

        // GET: Bandeiras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bandeira.ToListAsync());
        }

        // GET: Bandeiras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandeira = await _context.Bandeira
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bandeira == null)
            {
                return NotFound();
            }

            return View(bandeira);
        }

        // GET: Bandeiras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bandeiras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Descricao")] Bandeira bandeira)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bandeira);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bandeira);
        }

        // GET: Bandeiras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandeira = await _context.Bandeira.FindAsync(id);
            if (bandeira == null)
            {
                return NotFound();
            }
            return View(bandeira);
        }

        // POST: Bandeiras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Descricao")] Bandeira bandeira)
        {
            if (id != bandeira.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bandeira);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandeiraExists(bandeira.Id))
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
            return View(bandeira);
        }

        // GET: Bandeiras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandeira = await _context.Bandeira
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bandeira == null)
            {
                return NotFound();
            }

            return View(bandeira);
        }

        // POST: Bandeiras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bandeira = await _context.Bandeira.FindAsync(id);
            _context.Bandeira.Remove(bandeira);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandeiraExists(int id)
        {
            return _context.Bandeira.Any(e => e.Id == id);
        }
    }
}
