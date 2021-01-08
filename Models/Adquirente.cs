using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_K2iP.Models
{
    public class Adquirente
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        [ForeignKey("AdquirenteId")]
        public ICollection<Transacoes> Transacoes { get; set; }
    }
}
