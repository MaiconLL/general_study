using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUnitTest.CodigoATestar.Domain.Entities
{
    internal class Pedido
    {
        public int Id { get; set; }

        public string CPF { get; set; } = default!;

        public List<Product> Produtos { get; set; } = new List<Product>();

        public Pagamento Pagamento { get; set; } = default!;
    }
}
