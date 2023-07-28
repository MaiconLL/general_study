

//O Bridge é um padrão de design estrutural que permite dividir uma classe grande ou um conjunto de classes intimamente relacionadas
//em duas hierarquias separadas—abstração e implementação—que podem ser desenvolvidas independentemente uma da outra.

//o bridge nada mais é que separar uma funcionalidade que pode trabalhar independentemente, em uma abstração desta,
//de modo que o software principal e essa funcionalidade se tornem independentes um do outro, assim é possível acoplar diferentes implementações da mesma abstração

//Casos de uso:

//Quando você deseja dividir e organizar uma classe monolítica que tem várias variantes de algumas funcionalidades
//(por exemplo, se a classe pode ser implementada de várias maneiras diferentes).

//Quando você deseja substituir implementações em tempo de execução.

//Quando você precisa reduzir a quantidade de subclasses em sistemas de classes paralelas.

//Quando a mudança em uma classe não deve afetar outras classes.
//Isso é útil quando uma classe existe em várias plataformas ou sistemas operacionais e não queremos que uma alteração na plataforma / sistema operacional afete a própria classe.



Pessoa pessoaFisica = new PessoaFisica(new DocumentoPessoaFisica());

Pessoa pessoaJuridica = new PessoaJuridica(new DocumentoPessoaJuridica());


Console.WriteLine($"Fisica: {pessoaFisica.GetDocumento()}\nJuridica: {pessoaJuridica.GetDocumento()}");


interface IDocumento
{
    string GetDocumento();
}


class DocumentoPessoaFisica : IDocumento
{
    public string GetDocumento()
    {
        return "837.014.460-68";
    }
}

class DocumentoPessoaJuridica : IDocumento
{
    public string GetDocumento()
    {
        return "00.115.150/0001-40";
    }
}

abstract class Pessoa
{
    protected readonly IDocumento _documento;
    public Pessoa(IDocumento documento)
    {
        _documento = documento;
    }

    public string Nome { get; set; } = default!;

    public abstract string GetDocumento();
}

class PessoaFisica : Pessoa
{
    public PessoaFisica(IDocumento documento) : base(documento)
    {
    }

    public override string GetDocumento()
    {
        return _documento.GetDocumento();
    }
}

class PessoaJuridica : Pessoa
{
    public PessoaJuridica(IDocumento documento) : base(documento)
    {
    }

    public override string GetDocumento()
    {
        return _documento.GetDocumento();
    }
}

