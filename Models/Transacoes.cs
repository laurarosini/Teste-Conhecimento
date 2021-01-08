using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_K2iP.Models
{
    public class Transacoes
    {
        public int ID { get; set; }
        public int AdquirenteId { get; set; }
        public Adquirente Adquirente { get; set; }
        public string CodigoCliente { get; set; }
        public string DataTransacao { get; set; }
        public string HoraTransacao { get; set; }
        public string NumeroCartao { get; set; }
        public string CodigoAutorizacao { get; set; }
        public string NSU { get; set; }
        public int BandeiraId { get; set; }
        public Bandeira Bandeira { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorBruto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxaAdmin { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorLiquido { get; set; }
    }
}
