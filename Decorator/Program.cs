
//O padrão Decorator permite adicionar comportamentos adicionais a objetos em tempo de execução sem alterar sua classe.
//O padrão pode ser útil quando há uma necessidade de estender a funcionalidade de uma classe, mas não é possível ou prático usar a herança.
//O Decorator funciona envolvendo o objeto original dentro de um objeto de decoração que tem a mesma interface.

//Casos de Uso:
//O padrão Decorator é útil quando:

//Você quer adicionar responsabilidades a objetos individuais de forma dinâmica e transparente, sem afetar outros objetos.

//Você quer adicionar responsabilidades que podem ser retiradas.

//A extensão por subclasse é impraticável. Às vezes, um grande número de extensões independentes é possível e tornaria impraticável uma hierarquia de subclasses.
//O padrão Decorator proporciona uma maneira alternativa de fazer isso sem precisar de uma classe para cada combinação de decoradores.



Console.WriteLine("Não é um bom caso de uso pois podem existir milhares de principios ativos, mas o padrão de design se aplica assim");

Manipulado produto = new Capsula();
produto = new AcetatoAtosibana(produto);
produto = new Clonazepam(produto);

Console.WriteLine($"Nome: {produto.Nome}\nCusto: {produto.Custo}");



abstract class Manipulado
{
    public abstract string Nome { get; }
    public abstract double Custo { get; }
}

class Capsula : Manipulado
{
    public override string Nome => "Cápsula";

    public override double Custo => 1.23;
}

abstract class PrincipioAtivoDecorator : Manipulado
{
    protected Manipulado _manipulado;

    public PrincipioAtivoDecorator(Manipulado manipulado)
    {
        _manipulado = manipulado;
    }
}

class AcetatoAtosibana : PrincipioAtivoDecorator
{
    public AcetatoAtosibana(Manipulado manipulado) : base(manipulado)
    {
    }

    public override string Nome => _manipulado.Nome + ", ACETATO DE ATOSIBANA";

    public override double Custo => 2.36 + _manipulado.Custo;
}

class Clonazepam : PrincipioAtivoDecorator
{
    public Clonazepam(Manipulado manipulado) : base(manipulado)
    {
    }

    public override string Nome => _manipulado.Nome + ", CLONAZEPAM";

    public override double Custo => 4.59 + _manipulado.Custo;
}