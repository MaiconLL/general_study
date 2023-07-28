using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUnitTest.CodigoATestar.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Document { get; set; } = default!;
    }
}
