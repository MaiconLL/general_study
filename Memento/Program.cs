//O padrão Memento é usado para restaurar o estado de um objeto para um estado anterior.
//É muito útil em casos de algo que você possa precisar desfazer, como um comando de desfazer em um processador de texto,
//uma transação de banco de dados, o estado de um jogo salvo, etc.

//Detalhes:

//Originator: o objeto cujo estado precisa ser salvo e restaurado mais tarde. Ele cria um objeto memento para salvar seu estado.
//Memento: um objeto simples que contém o estado do Originator. O Memento não tem funções, é apenas um objeto de dados.
//Caretaker: responsável por manter o Memento. O Caretaker pode manter o histórico de Mementos e fornece a funcionalidade de desfazer e refazer.

//Casos de uso:

//Implementação de funcionalidades de desfazer/refazer.
//Fornecer uma "imagem instantânea" segura do estado de um objeto em um determinado momento, para que outros objetos possam fazer algo útil com essa imagem, mas sem a possibilidade de corromper o estado do objeto.
//Quando você precisa criar um backup do estado de certos objetos e restaurá-los quando necessário.
//Quando a obtenção do estado do objeto é mais complexa ou demorada e você deseja otimizar o desempenho fazendo backup do estado.


using System.ComponentModel;

var originator = new ClienteOriginator();
var historico = new Historico();
originator.Content = new Cliente() { Codigo = 1, Descricao = "Teste" };

historico.Push(originator.Save());

originator.Content = new Cliente() { Codigo = 2, Descricao = "Teste 2" };
historico.Push(originator.Save());

originator.Content = new Cliente() { Codigo = 3, Descricao = "Teste 3" };
originator.Restore(historico.Pop());

Console.WriteLine(originator.Content); 


class Cliente
{
    public int Codigo { get; set; }
    public string Descricao { get; set; } = default!;

    public override string ToString()
    {
        return $"{Codigo} - {Descricao}";
    }
}

class ClienteOriginator
{
    public Cliente Content { get; set; } = new Cliente();

    public ClienteMemento Save()
    {
        return new ClienteMemento(Content);
    }

    public void Restore(ClienteMemento memento)
    {
        Content = memento.Content;
    }
}

class ClienteMemento
{
    public Cliente Content { get; set; }
    public ClienteMemento(Cliente cliente)
    {
        Content = cliente;
    }
}

class Historico
{
    private Stack<ClienteMemento> _history = new Stack<ClienteMemento>();

    public void Push(ClienteMemento memento)
    {
        _history.Push(memento);
    }

    public ClienteMemento Pop()
    {
        return _history.Pop();
    }
}