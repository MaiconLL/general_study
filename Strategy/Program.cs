


//O padrão Strategy é um padrão de design comportamental que transforma um conjunto de comportamentos em objetos e os torna intercambiáveis dentro do contexto original.
//O padrão Strategy permite que o algoritmo varie independentemente dos clientes que o utilizam.



//Casos de uso do padrão Strategy:

//Quando você quer decidir em tempo de execução qual implementação de uma determinada interface usar.
//Quando você tem muitas classes relacionadas que diferem apenas no comportamento. A estratégia permite que você configure uma classe com um de muitos comportamentos.
//Quando você precisa de uma alternativa eficiente a uma cascata de instruções if-else ou switch-case. Isso pode ocorrer quando várias versões relacionadas de um algoritmo existem.
//Quando as classes diferentes não são adequadas para a utilização de herança ou o comportamento na hierarquia de classes precisa ser alterado dinamicamente.


try
{
    var comida = new Food(new FryingBehaviour());

    comida.AddIngredient("garlick");
    comida.Cook();
    comida.AddIngredient("onions");
    comida.Cook();

    comida.SetCookBehaviour(new CookingBehaviour());
    comida.AddIngredient("water");
    comida.Cook();
    comida.AddIngredient("rice");
    comida.Cook();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

interface ICookingBehaviour
{
    void Cook(Food food);
}

class CookingBehaviour : ICookingBehaviour
{
    public void Cook(Food food)
    {
        Console.WriteLine($"Cozinhando {food.CurrentIngredient}.");
    }
}

class FryingBehaviour : ICookingBehaviour
{
    public void Cook(Food food)
    {
        Console.WriteLine($"Fritando {food.CurrentIngredient}.");
    }
}

class Food
{
    public string CurrentIngredient { get; private set; } = default!;

    public readonly Stack<string> _ingredients = new Stack<string>();

    ICookingBehaviour _cookingBehaviour;

    public Food(ICookingBehaviour cookingBehaviour)
    {
        _cookingBehaviour = cookingBehaviour;
    }

    public void SetCookBehaviour(ICookingBehaviour cookingBehaviour)
    {
        _cookingBehaviour = cookingBehaviour;
    }

    public void AddIngredient(string ingredient)
    {
        CurrentIngredient = ingredient;
        _ingredients.Push(CurrentIngredient);
    }

    public void Cook()
    {
        if (string.IsNullOrWhiteSpace(CurrentIngredient)) throw new Exception("Você não colocou nenhum ingrediente e queimou a panela.");
        _cookingBehaviour.Cook(this);
    }
}