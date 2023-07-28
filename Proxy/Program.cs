
//O padrão Proxy é um padrão estrutural que fornece um substituto ou um espaço reservado para outro objeto para controlar o acesso a ele.

//Existem várias variações do padrão Proxy, incluindo:

//Proxy remoto: fornece uma referência local a um objeto que reside em um espaço de endereço diferente.
//Proxy virtual: Usado para otimização, como a criação sob demanda de um objeto pesado.
//Proxy de proteção: protege o objeto original de operações invasivas ou não seguras.
//Proxy inteligente: Insere funcionalidades adicionais quando um objeto é acessado.


var conta = new ProxyContaBancoReal();

try
{
    conta.GetSaldo();
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine(ex.ToString());
}
conta.Autenticar("123", "abc");
Console.WriteLine($"Saldo: {conta.GetSaldo()}");

var image = conta.GetImage();
//TO DO 

class ContaBancoReal : IContaBanco
{
    byte[]? _imageUser = null;

    public byte[]? GetImage()
    {
        return _imageUser;
    }

    internal void LoadDiskImage()
    {
        //carregamento pesado
        _imageUser = new byte[32];
    }

    public double GetSaldo()
    {
        //pesquisa/processa
        return 230_123_566;
    }
}

class ProxyContaBancoReal : IContaBanco
{
    private ContaBancoReal _contaBancoReal;
    private bool _autenticado = false;

    public ProxyContaBancoReal()
    {
        _contaBancoReal = new ContaBancoReal();
    }


    public byte[] GetImage()
    {
        if (_contaBancoReal.GetImage() == null)
            _contaBancoReal.LoadDiskImage();
        return _contaBancoReal.GetImage()!;
    }

    public double GetSaldo()
    {
        if (!_autenticado) throw new UnauthorizedAccessException("Unauthorized");
        return _contaBancoReal.GetSaldo();
    }

    public void Autenticar(string user, string name)
    {
        if (user == "123" && name == "abc")
            _autenticado = true;
        else
            throw new UnauthorizedAccessException("Unauthorized");
    }
}


public interface IContaBanco
{
    double GetSaldo();
    byte[]? GetImage();
}