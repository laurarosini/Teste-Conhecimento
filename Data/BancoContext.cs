using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste_K2iP.Models;

namespace Teste_K2iP.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext (DbContextOptions<BancoContext> options)
            : base(options)
        {
        }

        public DbSet<Teste_K2iP.Models.Transacoes> Transacoes { get; set; }

        public DbSet<Teste_K2iP.Models.Bandeira> Bandeira { get; set; }

        public DbSet<Teste_K2iP.Models.Adquirente> Adquirente { get; set; }
    }
}
