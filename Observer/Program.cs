

//O padrão de design Observer, também conhecido como "Publish-Subscribe", permite que um objeto notifique outros objetos sobre mudanças em seu estado.
//O objeto que está sendo observado é chamado de "Subject", enquanto os objetos que observam o estado do "Subject" são chamados de "Observers" ou "Listeners".

//Detalhes:

//Subject: Mantém uma lista de observadores. Ele facilita a adição ou remoção de observadores. E é responsável por notificar os observadores quando há alguma mudança.

//Observer: Define uma interface de atualização para os objetos que devem ser notificados de uma mudança no Subject.

//Casos de uso:

//Quando um objeto precisa ser notificado sobre mudanças em outro objeto.
//Para permitir um acoplamento frouxo entre classes.
//Quando uma mudança em um objeto requer mudanças em outros, e você não sabe quantos objetos precisam ser alterados.
//Para uma atualização em tempo real, como em feeds ao vivo, onde, por exemplo, o Subject é o feed de notícias e os Observers são os usuários que se inscreveram nesse feed.


using System;

ObservableCliente observable = new ObservableCliente();
ObserverCliente observer = new ObserverCliente();
using (observable.Subscribe(observer))
{
    observable.ProcessChanges(new Cliente() { Codigo = 1, Descricao = "Teste"});
    observable.ProcessChanges(new Cliente() { Codigo = 2, Descricao = "Teste2"});
}
Console.ReadLine();



class Cliente
{
    public int Codigo { get; set; }
    public string Descricao { get; set; } = default!;

    public override string ToString()
    {
        return $"{Codigo} - {Descricao}";
    }
}


class ObserverCliente : IObserver<Cliente>
{
    Cliente _cliente = default!;
    public void OnCompleted()
    {
        Console.WriteLine($"Concluído: {_cliente} ");
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($"Erro observado: {error.Message}");
    }

    public void OnNext(Cliente value)
    {
        _cliente = value;
        Console.WriteLine($"Observou - {_cliente}");
    }
}

class ObservableCliente : IObservable<Cliente>
{
    public List<IObserver<Cliente>> _observers = new List<IObserver<Cliente>>();

    public IDisposable Subscribe(IObserver<Cliente> observer)
    {
        _observers.Add(observer);
        return new Unsubscriber(_observers, observer);
    }

    private class Unsubscriber : IDisposable
    {
        private List<IObserver<Cliente>> _observers;
        private IObserver<Cliente> _observer;

        public Unsubscriber(List<IObserver<Cliente>> observers, IObserver<Cliente> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }

    public void ProcessChanges(Cliente value)
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(value);
            observer.OnCompleted();
        }
    }

    public void Complete()
    {
        foreach (var observer in _observers)
        {
            observer.OnCompleted();
        }
        _observers.Clear();
    }
}

