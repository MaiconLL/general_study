using Moq;
using SimpleUnitTest.CodigoATestar.Application;
using SimpleUnitTest.CodigoATestar.Domain;
using SimpleUnitTest.CodigoATestar.Domain.Contracts;
using SimpleUnitTest.CodigoATestar.Domain.Entities;
using SimpleUnitTest.CodigoATestar.Domain.Exception;
using SimpleUnitTest.CodigoATestar.Infrastructure;

namespace SimpleUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestUnit_CreateProduct_ShouldCreateProductSuccessfully()
        {
            //Arrange
            var productController = new ProductController(new ProductRepository());

            var product = new Product() { Id = 1, Description = "Teste", Price = 1 };

            //Act

            productController.Gravar(product);

            //Assert

            var existe = productController.Buscar(id: 1);
            Assert.NotNull(existe);

        }

        [Fact]
        public void TestUnit_CreateProduct_ShouldExceptBecausePriceLessThanZero()
        {
            //Arrange
            var productController = new ProductController(new ProductRepository());

            var product = new Product() { Id = 1, Description = "Teste", Price = 0 };

            //Act
            //Assert

            Assert.Throws<DataInvalidException>(() =>
            {
                productController.Gravar(product);
            });
        }

        [Fact]
        public void TestIntegracao_CreatePedido_ShouldCreatePedidoSuccessfully()
        {
            //Arrange

            var pedidoController = new PedidoController(new PedidoRepository());

            var productController = new ProductController(new ProductRepository());

            var product = new Product() { Id = 1, Description = "Teste", Price = 2.25m };

            var pagamento = new { formaPagamento = "DINHEIRO", valor = 2.25m };

            var cpf = "837.014.430-68";

            //Act

            pedidoController.CriarPedido(cpf);
            pedidoController.AdicionarProduto(product);
            var idPedido = pedidoController.FinalizarPedido(pagamento.formaPagamento, pagamento.valor);

            //Assert

            var existe = pedidoController.BuscarPedido(idPedido);
            Assert.NotNull(existe);
        }

        [Fact]
        public void TestIntegracao_CreatePedido_ShouldExceptBecausePagamentoDifferentSumProducts()
        {
            //Arrange

            var pedidoController = new PedidoController(new PedidoRepository());

            var productController = new ProductController(new ProductRepository());

            var product = new Product() { Id = 1, Description = "Teste", Price = 2.25m };

            var pagamento = new { formaPagamento = "DINHEIRO", valor = 1m };

            var cpf = "837.014.430-68";

            //Act
            //Assert

            pedidoController.CriarPedido(cpf);
            pedidoController.AdicionarProduto(product);

            Assert.Throws<Exception>(() =>
            {
                var idPedido = pedidoController.FinalizarPedido(pagamento.formaPagamento, pagamento.valor);
            });
        }

        [Fact]
        public void TestMock_GetClienteShouldBringSuccessfully()
        {
            //Arrange
            var mockRepoCliente = new Mock<IRepository<Cliente>>();
            mockRepoCliente.Setup(x => x.GetSequence()).Returns(1);
            mockRepoCliente.Setup(x => x.Create(It.Is<Cliente>(x => x.Document == "837.014.430-68")));
            mockRepoCliente.Setup(x => x.GetById(It.Is<int>(x=>x.Equals(1)))).Returns(new Cliente() { Id = 1 });
            var clienteController = new ClienteController(mockRepoCliente.Object);

            //Act

            var cliente = clienteController.BuscarCliente(1);

            //Assert

            Assert.NotNull(cliente);

        }
    }
}