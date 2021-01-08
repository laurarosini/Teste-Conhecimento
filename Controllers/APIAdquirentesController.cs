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
    public class APIAdquirentesController : ControllerBase
    {
        private readonly BancoContext _context;

        public APIAdquirentesController(BancoContext context)
        {
            _context = context;
        }

        // GET: api/APIAdquirentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adquirente>>> GetAdquirente()
        {
            return await _context.Adquirente.ToListAsync();
        }

        // GET: api/APIAdquirentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adquirente>> GetAdquirente(int id)
        {
            var adquirente = await _context.Adquirente.FindAsync(id);

            if (adquirente == null)
            {
                return NotFound();
            }

            return adquirente;
        }

        // PUT: api/APIAdquirentes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdquirente(int id, Adquirente adquirente)
        {
            if (id != adquirente.Id)
            {
                return BadRequest();
            }

            _context.Entry(adquirente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdquirenteExists(id))
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

        // POST: api/APIAdquirentes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Adquirente>> PostAdquirente(Adquirente adquirente)
        {
            _context.Adquirente.Add(adquirente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdquirente", new { id = adquirente.Id }, adquirente);
        }

        // DELETE: api/APIAdquirentes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Adquirente>> DeleteAdquirente(int id)
        {
            var adquirente = await _context.Adquirente.FindAsync(id);
            if (adquirente == null)
            {
                return NotFound();
            }

            _context.Adquirente.Remove(adquirente);
            await _context.SaveChangesAsync();

            return adquirente;
        }

        private bool AdquirenteExists(int id)
        {
            return _context.Adquirente.Any(e => e.Id == id);
        }
    }
}
