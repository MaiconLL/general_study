using SimpleUnitTest.CodigoATestar.Domain.Contracts;
using SimpleUnitTest.CodigoATestar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUnitTest.CodigoATestar.Infrastructure
{
    internal class PedidoRepository : IRepository<Pedido>
    {
        private readonly Dictionary<int, Pedido> _pedidos;

        public PedidoRepository()
        {
            _pedidos = new Dictionary<int, Pedido>();
        }

        public void Create(Pedido pedido)
        {
            if (_pedidos.ContainsKey(pedido.Id)) throw new Exception("Duplicidade de chave.");
            _pedidos[pedido.Id] = pedido;
        }

        public Pedido GetById(int id)
        {
            if (!_pedidos.ContainsKey(id)) throw new Exception("Não encontrado.");
            return _pedidos[id];
        }

        public int GetSequence()
        {
            return _pedidos.Count == 0 ? 1 : _pedidos.Keys.Max() + 1;
        }
    }
}
