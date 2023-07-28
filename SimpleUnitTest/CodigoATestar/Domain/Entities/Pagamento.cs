using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUnitTest.CodigoATestar.Domain.Entities
{
    internal class Pagamento
    {
        public string Descricao { get; set; } = default!;
        public decimal Valor { get; set; }
    }
}
