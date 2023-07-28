
//O Facade é um padrão de design estrutural que fornece uma interface simplificada para uma biblioteca,
//um framework ou qualquer outro conjunto complexo de classes. Este padrão sugere que você crie uma nova classe com métodos mais simplificados,
//os quais delegam o trabalho para os métodos das classes já existentes.

//basicamente é criar uma classe extra que faz o papel de executar os métodos de uma biblioteca de terceiros de um modo agrupado, quando a biblioteca tem muita complexidade no modo que opera



//Casos de uso:

//Quando você deseja fornecer uma interface simples para um subsistema complexo.
//Facades podem ajudar a minimizar as dependências de um cliente para um subsistema complexo.

//Quando você deseja decompor subsistemas em camadas.
//Você pode usar uma fachada para definir pontos de entrada para cada nível de subsistema.
//Se os subsistemas são dependentes, você pode simplificar as dependências entre eles fazendo-os se comunicar uns com os outros exclusivamente através de suas fachadas.

Console.WriteLine("");
class ExecutionCommandFacade
{
    private readonly IDBase _dBase;
    public ExecutionCommandFacade(IDBase dBase)
    {
        _dBase = dBase;
    }

    public void ExecutarComando(string comando)
    {
        _dBase.OpenConnection();
        _dBase.BeginTransaction();
        _dBase.Execute(comando);
        _dBase.CommitTransaction();
        _dBase.CloseConnection();
    }
}


interface IDBase
{
    void OpenConnection();
    void BeginTransaction();
    int Execute(string command);
    void CommitTransaction();
    void CloseConnection();
}