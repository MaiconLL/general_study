//O padrão de design Adapter é um padrão estrutural que permite que objetos com interfaces incompatíveis colaborem.

//O Adapter atua como um invólucro entre dois objetos.
//Ele pega a interface de um objeto e a transforma em uma interface compreendida por outro objeto.

//Integração de sistemas: O Adapter é amplamente usado ao integrar novos componentes a sistemas existentes que usam diferentes interfaces.

//Refatoração de código: O padrão Adapter é frequentemente usado em código que precisa ser refatorado.

//Conexão de bibliotecas antigas a classes modernas:
//O Adapter pode ser útil ao tentar usar uma biblioteca ou classe existente com uma interface incompatível com o restante do código do seu projeto.

//Transformar diferentes formatos de dados para um formato unificado:
//Por exemplo, se você estiver lidando com vários formatos de arquivos (XML, CSV, JSON),
//você pode criar adaptadores para cada formato de arquivo e depois acessar todos eles por meio de uma única interface comum.


FuncionarioLegado funcionarioLegado = new FuncionarioLegado();
IFuncionario funciona = new FuncionarioAdapter(funcionarioLegado);

Console.WriteLine(funciona.GetNomeCompleto());

class FuncionarioLegado
{
    public string GetNome() => "Maicon";

    public string GetSobrenome() => "Loti";
}

interface IFuncionario
{
    string GetNomeCompleto();
}

class FuncionarioAdapter : IFuncionario
{
    private readonly FuncionarioLegado _funcionarioLegado;
    public FuncionarioAdapter(FuncionarioLegado funcionarioLegado)
    {
        _funcionarioLegado = funcionarioLegado;
    }

    public string GetNomeCompleto()
    {
        return $"{_funcionarioLegado.GetNome()} {_funcionarioLegado.GetSobrenome()}";
    }
}