
//O padrão Command é um padrão comportamental que transforma uma solicitação em um objeto autônomo que contém todas as informações sobre a solicitação.
//Este padrão de transformação permite que métodos sejam parametrizados com diferentes solicitações, atrasar ou colocar a execução da solicitação em filas,
//além de suportar operações que podem ser desfeitas.

//A ideia é encapsular a ação como um objeto, permitindo que você armazene de forma parametrizável os detalhes da ação,
//como o método a ser chamado, os valores dos parâmetros etc.


//Casos de uso

//O padrão Command é comumente usado em situações onde precisamos:

//Parametrizar objetos de acordo com uma ação a ser executada.
//Especificar, enfileirar e executar solicitações em momentos diferentes.
//Oferecer suporte para operações que podem ser desfeitas.
//Criar uma estrutura para operações de alto nível que usam operações primitivas.

//MVVM é um bom exemplo de uso de Command


var controllerProduto = new Controller(new ProdutoRepository());
var controllerCliente = new Controller(new ClienteRepository());

controllerProduto.Deletar();
controllerProduto.Gravar();
controllerCliente.Deletar();
controllerCliente.Gravar();



class Controller
{
    private readonly IRepository _repository;
    public Controller(IRepository repository)
    {
        _repository = repository;
    }

    public void Gravar()
    {
        ICommand gravarCommand = new GravarCommand(_repository);
        gravarCommand.Execute();
    }

    public void Deletar()
    {
        ICommand deletarCommand = new DeletarCommand(_repository);
        deletarCommand.Execute();
    }
}

interface IRepository
{
    void Gravar();
    void Deletar();
}

class ClienteRepository : IRepository
{
    public void Deletar()
    {
        Console.WriteLine($"Deletando Cliente");
    }

    public void Gravar()
    {
        Console.WriteLine($"Gravando Cliente");
    }
}

class ProdutoRepository : IRepository
{
    public void Deletar()
    {
        Console.WriteLine($"Deletando Produto");
    }

    public void Gravar()
    {
        Console.WriteLine($"Gravando Produto");
    }
}

interface ICommand
{
    void Execute();
}


class GravarCommand : ICommand
{
    private readonly IRepository _repository;
    public GravarCommand(IRepository repository)
    {
        _repository = repository;
    }

    public void Execute()
    {
        _repository.Gravar();
    }
}

class DeletarCommand : ICommand
{
    private readonly IRepository _repository;
    public DeletarCommand(IRepository repository)
    {
        _repository = repository;
    }

    public void Execute()
    {
        _repository.Deletar();
    }
}