//O padrão de design Flyweight é um padrão estrutural que permite que um programa suporte um grande número de objetos com um custo mínimo de memória.
//O Flyweight consegue isso compartilhando o máximo possível de dados entre objetos similares.

//O padrão Flyweight é útil quando se tem um grande número de objetos que compartilham muitos estados em comum.
//Em vez de armazenar todos os dados em cada objeto individualmente, o padrão Flyweight armazena os dados compartilhados
//em um objeto separado (o flyweight) e o referencia a partir dos objetos individuais.

//Os casos de uso comuns para o padrão Flyweight incluem otimização de memória em jogos ou gráficos onde existem muitos objetos que compartilham um estado comum,
//como texturas ou modelos 3D, ou em editores de texto onde cada caractere na tela poderia ser um objeto,
//mas compartilha muito estado com outros caracteres (como o tipo de fonte, cor, etc.).

CharacterFactory factory = new CharacterFactory();

Character characterA = factory.GetCharacter('A', "Times New Roman");
characterA.Draw(10, 20);

Character characterA2 = factory.GetCharacter('A', "Times New Roman");
characterA2.Draw(10, 20);


public class Character
{
    private readonly char _symbol;
    private readonly string _font;

    public Character(char symbol, string font)
    {
        _symbol = symbol;
        _font = font;
    }

    public void Draw(int x, int y)
    {
        Console.WriteLine($"Drawing character '{_symbol}' in font '{_font}' at position ({x}, {y})");
    }
}

public class CharacterFactory
{
    private readonly Dictionary<char, Character> _characters = new Dictionary<char, Character>();

    public Character GetCharacter(char symbol, string font)
    {
        if (!_characters.ContainsKey(symbol))
        {
            _characters[symbol] = new Character(symbol, font);
        }
        return _characters[symbol];
    }
}



