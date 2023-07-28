


//O padrão Interpreter é um dos padrões de projeto comportamentais definidos pelo Gang of Four (GoF) em seu livro Design Patterns:
//Elements of Reusable Object-Oriented Software.
//Esse padrão é utilizado para definir uma representação gramatical para uma linguagem e fornecer um interpretador para lidar com essa gramática.


//Quando usar:
//Você deve usar o padrão Interpreter quando:

//Há uma linguagem ou gramática simples a ser interpretada. Este é geralmente o caso com linguagens de programação,
//mas também pode ser usado para formatos de arquivo (como XML ou JSON), protocolos de comunicação, etc.
//Você precisa realizar várias operações diferentes na árvore de sintaxe da linguagem.
//Você quer separar as regras gramaticais da lógica do programa principal.


var codigoUm = new EqualityExpression("Codigo", "1");
var nomeMaicon = new LikeExpression("Nome", "Mai",LikeType.Start);
var nomeJoao = new LikeExpression("Nome", "Joao",LikeType.Start);

var andCompararTrue = new AndExpression(nomeMaicon, codigoUm);
var andCompararFalse = new AndExpression(nomeJoao, codigoUm);
var teste = andCompararTrue.Interpret(new Registro(("Codigo", "1"), ("Nome", "Maicon")));
var testeFalse = andCompararFalse.Interpret(new Registro(("Codigo", "1"), ("Nome", "Maicon")));


Console.WriteLine(teste.ToString());


interface IExpression
{
    bool Interpret(Registro context);
}

class Registro
{
    public Registro(params (string key, string value)[] celulas)
    {
        foreach (var item in celulas)
        {
            if (Celulas.ContainsKey(item.key)) throw new Exception("Não pode haver celulas duplicadas.");
            Celulas.Add(item.key, item.value);
        }
    }

    public Dictionary<string, string> Celulas { get; set; } = new Dictionary<string, string>();
}

enum LikeType
{
    Start,
    End,
    All
}

class LikeExpression : IExpression
{
    private string _variable;
    private string _valor;
    private LikeType _likeType;
    public LikeExpression(string variable, string valor, LikeType likeType)
    {
        _variable = variable;
        _valor = valor;
        _likeType = likeType;
    }

    public bool Interpret(Registro context)
    {

        switch (_likeType)
        {
            case LikeType.Start:
                return context.Celulas[_variable].StartsWith(_valor);
            case LikeType.End:
                return context.Celulas[_variable].EndsWith(_valor);
            default:
                return context.Celulas[_variable].Contains(_valor);
        }
    }
}

class EqualityExpression : IExpression
{
    private string _variable;
    private string _valor;
    public EqualityExpression(string variable, string valor)
    {
        _variable = variable;
        _valor = valor;
    }

    public bool Interpret(Registro context)
    {
        return context.Celulas[_variable].Equals(_valor);
    }
}

class AndExpression : IExpression
{
    private IExpression expr1;
    private IExpression expr2;

    public AndExpression(IExpression expr1, IExpression expr2)
    {
        this.expr1 = expr1;
        this.expr2 = expr2;
    }

    public bool Interpret(Registro context)
    {
        return expr1.Interpret(context) && expr2.Interpret(context);
    }
}