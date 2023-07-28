



//O padrão de projeto Template Method é um padrão comportamental que define a estrutura de um algoritmo em uma superclasse,
//mas permite que as subclasses substituam partes específicas desse algoritmo sem alterar a estrutura.

//O Template Method estabelece um esqueleto de um algoritmo em uma operação, preservando algumas etapas para serem redefinidas por subclasses.
//Portanto, ele permite que subclasses redefinam certos passos de um algoritmo sem alterar a estrutura do mesmo.

//O padrão Template Method é usado em uma série de situações:

//Quando subclasses devem estender a funcionalidade de uma superclasse, mas não devem alterar a estrutura do algoritmo.
//Quando há um código duplicado em muitas classes, o padrão Template Method é frequentemente usado para refatorar o código e eliminar a duplicação.
//Quando você quer fornecer uma maneira fácil para os clientes estenderem apenas certas partes de um algoritmo grande.


var pessoaFisicaRepo = new PessoaFisicaRepository();

Console.WriteLine(pessoaFisicaRepo.GetDocument(1));
pessoaFisicaRepo.Save(new Pessoa(1, "Joao", "999.999.999-99"));

var pessoaJuridicaRepo = new PessoaJuridicaRepository();
Console.WriteLine(pessoaJuridicaRepo.GetDocument(1));
pessoaFisicaRepo.Save(new Pessoa(2, "Google", "99.999.999/0001-99"));


record Pessoa(int Id, string Nome, string Document);
abstract class PessoaRepository
{

    public void Save(Pessoa pessoa)
    {
        //gravar em banco
        Console.WriteLine($"Gravando {pessoa.Id} - {pessoa.Nome} em banco");
    }

    public Pessoa Get(int id)
    {
        //TODO
        return new Pessoa(id, "", "");
    }

    public abstract string GetDocument(int id);

}

class PessoaFisicaRepository : PessoaRepository
{
    public override string GetDocument(int id)
    {
        //pesquisa CPF
        return "999.999.999-99";
    }
}

class PessoaJuridicaRepository : PessoaRepository
{
    public override string GetDocument(int id)
    {
        //pesquisa CNPJ
        return "99.999.999/0001-99";
    }
}