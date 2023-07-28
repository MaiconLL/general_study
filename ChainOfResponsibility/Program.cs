

//Chain of Responsibility é um padrão de design comportamental que permite que um objeto passe solicitações ao longo de uma cadeia de manipuladores.
//Ao receber uma solicitação, cada manipulador decide se processa a solicitação ou a passa para o próximo manipulador na cadeia.
//também é possível adaptar para que mais de um dos manipuladores, manipulem a mesma requisição
//por exemplo no caso de uma requisição web aonde é enviado um cliente e se deseja adicionar envio de email para o cliente após o cadastro


//Casos de uso:

//Quando mais de um objeto pode tratar uma solicitação, e o objeto que o manipula não é conhecido a priori. O objeto que tratará a solicitação deve ser escolhido automaticamente.
//Quando o conjunto de objetos que pode tratar uma solicitação deve ser especificado dinamicamente.
//Quando uma solicitação deve ser emitida para vários objetos sem especificar explicitamente o receptor.
//Quando a cadeia de responsabilidade é uma lista de objetos que podem tratar a solicitação em sequência, você pode passar a solicitação ao longo da cadeia até que um objeto a trate.


Manipulador manipulador1 = new ManipuladorConcreto1();
Manipulador manipulador2 = new ManipuladorConcreto2();

manipulador1.SetaProximo(manipulador2);

manipulador1.Manipular("1");
manipulador1.Manipular("2");



abstract class Manipulador
{
    protected Manipulador? _proximoManipulador;

    public Manipulador SetaProximo(Manipulador manipulador)
    {
        _proximoManipulador = manipulador;
        return manipulador;
    }

    public abstract void Manipular(string request);
}

class ManipuladorConcreto1 : Manipulador
{
    public override void Manipular(string request)
    {
        if(request == "1")
        {
            Console.WriteLine("Manipulado pelo primeiro");
        }
        else
        {
            _proximoManipulador?.Manipular(request);
        }
    }
}

class ManipuladorConcreto2 : Manipulador
{
    public override void Manipular(string request)
    {
        if(request == "2")
        {
            Console.WriteLine("Manipulado pelo segundo");
        }
        else
        {
            _proximoManipulador?.Manipular(request);
        }
    }
}