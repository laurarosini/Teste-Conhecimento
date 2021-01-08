using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teste_K2iP.Data;
using Teste_K2iP.Models;

namespace Teste_K2iP.Controllers
{
    public class TransacoesController : Controller
    {
        private readonly BancoContext _context;

        public TransacoesController(BancoContext context)
        {
            _context = context;
        }

        // GET: Transacoes
        public async Task<IActionResult> Index()
        {
            List<Adquirente> adquirentes = new List<Adquirente>();
            ViewBag.AdquirenteId = new SelectList
                (
                    adquirentes = _context.Adquirente.ToList()
                );

            //List<Adquirente> adquirentes = new List<Adquirente>();
            //ViewBag.AdquirenteId = adquirentes = _context.Adquirente.ToList();
            //ViewBag.Adquirentes = (IEnumerable<Adquirente>)ViewData["AdquirenteId"];

            ViewBag.Adquirentes = new SelectList(_context.Set<Adquirente>(), "Id", "Descricao");

            var bancoContext = _context.Transacoes.Include(t => t.Adquirente).Include(t => t.Bandeira);
            return View(await bancoContext.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormCollection form)
        {
            string strDDLValue = form["AdquirenteId"].ToString();

            var transacoes = _context.Transacoes;
            foreach (Transacoes T in transacoes)
            {
                _context.Adquirente.Where(x => x.Id == T.AdquirenteId).Load();
            }

            ViewData["AdquirenteId"] = transacoes;

            ViewBag.Transacoes = new SelectList(_context.Set<Transacoes>(), "ID", "CodigoCliente");

            return View();
        }

        // GET: Transacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacoes = await _context.Transacoes
                .Include(t => t.Adquirente)
                .Include(t => t.Bandeira)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transacoes == null)
            {
                return NotFound();
            }

            return View(transacoes);
        }

        // GET: Transacoes/Create
        public IActionResult Create()
        {
            ViewData["AdquirenteId"] = new SelectList(_context.Set<Adquirente>(), "Id", "Id");
            ViewData["BandeiraId"] = new SelectList(_context.Set<Bandeira>(), "Id", "Id");
            ViewBag.Adquirentes = _context.Adquirente.ToList();
            ViewBag.Bandeiras = _context.Bandeira.ToList();
            return View();
        }

        // POST: Transacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AdquirenteId,CodigoCliente,DataTransacao,HoraTransacao,NumeroCartao,CodigoAutorizacao,NSU,BandeiraId,ValorBruto,TaxaAdmin,ValorLiquido")] Transacoes transacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdquirenteId"] = new SelectList(_context.Set<Adquirente>(), "Id", "Id", transacoes.AdquirenteId);
            ViewData["BandeiraId"] = new SelectList(_context.Set<Bandeira>(), "Id", "Id", transacoes.BandeiraId);
            return View(transacoes);
        }

        // GET: Transacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacoes = await _context.Transacoes.FindAsync(id);
            if (transacoes == null)
            {
                return NotFound();
            }
            ViewData["AdquirenteId"] = new SelectList(_context.Set<Adquirente>(), "Id", "Id", transacoes.AdquirenteId);
            ViewData["BandeiraId"] = new SelectList(_context.Set<Bandeira>(), "Id", "Id", transacoes.BandeiraId);
            ViewBag.Adquirentes = _context.Adquirente.ToList();
            ViewBag.Bandeiras = _context.Bandeira.ToList();
            return View(transacoes);
        }

        // POST: Transacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AdquirenteId,CodigoCliente,DataTransacao,HoraTransacao,NumeroCartao,CodigoAutorizacao,NSU,BandeiraId,ValorBruto,TaxaAdmin,ValorLiquido")] Transacoes transacoes)
        {
            if (id != transacoes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransacoesExists(transacoes.ID))
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
            ViewData["AdquirenteId"] = new SelectList(_context.Set<Adquirente>(), "Id", "Id", transacoes.AdquirenteId);
            ViewData["BandeiraId"] = new SelectList(_context.Set<Bandeira>(), "Id", "Id", transacoes.BandeiraId);
            return View(transacoes);
        }

        // GET: Transacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacoes = await _context.Transacoes
                .Include(t => t.Adquirente)
                .Include(t => t.Bandeira)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transacoes == null)
            {
                return NotFound();
            }

            return View(transacoes);
        }

        // POST: Transacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transacoes = await _context.Transacoes.FindAsync(id);
            _context.Transacoes.Remove(transacoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacoesExists(int id)
        {
            return _context.Transacoes.Any(e => e.ID == id);
        }

        [Route("export")]
        [HttpGet]
        public ActionResult ExportCSVFile()
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("pt-BR"));
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true)))
                {
                    using (var cw = new CsvWriter(sw, cc))
                    {
                        List<Transacoes> transacoes = new List<Transacoes>();

                        transacoes = _context.Transacoes.ToList();

                        cw.WriteRecords(transacoes);
                    }

                    // The stream gets flushed here.
                    return File(ms.ToArray(), "text/csv", "transacoes.csv");
                }
            }
        }
    }
}
