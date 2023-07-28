using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUnitTest.CodigoATestar.Domain.Entities
{
    internal class Product
    {
        public int Id { get; set; }

        public string Description { get; set; } = default!;

        public decimal Price { get; set; }
    }
}
