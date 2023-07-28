using SimpleUnitTest.CodigoATestar.Domain.Contracts;
using SimpleUnitTest.CodigoATestar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUnitTest.CodigoATestar.Application
{
    internal class PedidoController
    {
        private Pedido? _pedido;
        private readonly IRepository<Pedido> _repository;
        public PedidoController(IRepository<Pedido> repository)
        {
            _repository = repository;
        }

        public void CriarPedido(string cpf)
        {
            _pedido = new Pedido();
            _pedido.CPF = cpf;
            _pedido.Produtos = new List<Product>();
        }

        public void AdicionarProduto(Product produto)
        {
            if (_pedido is null) throw new Exception("Pedido precisa ser criado.");
            _pedido.Produtos.Add(produto);
        }

        public int FinalizarPedido(string formaPagamento, decimal valor)
        {
            if (_pedido is null)
                throw new Exception("Pedido precisa ser criado.");

            if (_pedido.Produtos.Count <= 0)
                throw new Exception("Pedido precisa conter ao menos um produto.");

            if (_pedido.Produtos.Sum(x => x.Price) != valor)
                throw new Exception("Valor dos itens não confere com o valor do pagamento.");

            _pedido.Pagamento = new Pagamento() { Descricao = formaPagamento, Valor = valor };
            _pedido.Id = _repository.GetSequence();
            _repository.Create(_pedido);

            return _pedido.Id;
        }

        public Pedido? BuscarPedido(int id)
        {
            return _repository.GetById(id);
        }
    }
}
