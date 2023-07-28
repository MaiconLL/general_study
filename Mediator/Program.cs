

//Mediator é um padrão de design comportamental que permite reduzir as dependências caóticas entre os objetos.
//O padrão restringe as comunicações diretas entre os objetos e os força a colaborar apenas através de um objeto mediador.

//Esse padrão é uma ótima opção quando você está lidando com um número grande de objetos que estão interagindo uns com os outros.
//Se eles estiverem interagindo diretamente, você pode acabar com um sistema muito complexo e difícil de entender e manter.

using MediatR;
using Microsoft.Extensions.DependencyInjection;


IServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(typeof(Program).Assembly);
})
    .AddSingleton<OrdersController>()
    .AddSingleton<IOrderRepository, OrderRepository>();

IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

var controller = serviceProvider.GetRequiredService<OrdersController>();

var order = await controller.GetOrder(1);

Console.WriteLine(order?.Description);

class OrdersController
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Order?> GetOrder(int id)
    {
        var query = new GetOrderByIdQuery(id);
        var order = await _mediator.Send(query);

        if (order == null)
        {
            return null;
        }

        return order;
    }
}

class GetOrderByIdQuery : IRequest<Order>
{
    public int Id { get; set; }

    public GetOrderByIdQuery(int id)
    {
        Id = id;
    }
}

class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderById(request.Id);
        return order;
    }
}

class Order
{
    public int Id { get; set; }
    public string Description { get; set; } = default!;
}

interface IOrderRepository
{
    Task<Order> GetOrderById(int id);
}

class OrderRepository : IOrderRepository
{
    public async Task<Order> GetOrderById(int id)
    {
        return await Task.FromResult(new Order() { Id = id, Description = "teste" });
    }
}