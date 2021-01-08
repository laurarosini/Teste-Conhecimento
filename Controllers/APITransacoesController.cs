using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_K2iP.Data;
using Teste_K2iP.Models;

namespace Teste_K2iP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APITransacoesController : ControllerBase
    {
        private readonly BancoContext _context;

        public APITransacoesController(BancoContext context)
        {
            _context = context;
        }

        // GET: api/APITransacoes
        [HttpGet]
        public async Task<ActionResult<IList<Transacoes>>> GetTransacoes()
        {
            try
            {
                return await _context.Transacoes.Include(t => t.Adquirente).Include(t => t.Bandeira).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            
        }

        // GET: api/APITransacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transacoes>> GetTransacoes(int id)
        {
            var transacoes = await _context.Transacoes.FindAsync(id);

            if (transacoes == null)
            {
                return NotFound();
            }

            return transacoes;
        }

        // PUT: api/APITransacoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransacoes(int id, Transacoes transacoes)
        {
            if (id != transacoes.ID)
            {
                return BadRequest();
            }

            _context.Entry(transacoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransacoesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/APITransacoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Transacoes>> PostTransacoes(Transacoes transacoes)
        {
            _context.Transacoes.Add(transacoes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransacoes", new { id = transacoes.ID }, transacoes);
        }

        // DELETE: api/APITransacoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transacoes>> DeleteTransacoes(int id)
        {
            var transacoes = await _context.Transacoes.FindAsync(id);
            if (transacoes == null)
            {
                return NotFound();
            }

            _context.Transacoes.Remove(transacoes);
            await _context.SaveChangesAsync();

            return transacoes;
        }

        private bool TransacoesExists(int id)
        {
            return _context.Transacoes.Any(e => e.ID == id);
        }
    }
}
