

//O padrão de design Visitor permite que você adicione ou defina operações a serem realizadas em elementos de uma estrutura de objetos,
//sem alterar os elementos em si.
//Isso é especialmente útil quando você precisa definir novas operações sem alterar as classes dos elementos sobre os quais elas operam.

//Casos de uso
//Quando você precisa realizar operações em uma estrutura complexa de objetos, como um documento composto por uma hierarquia de objetos simples
//e complexos.

//Quando as operações devem ser distintas e diferentes dependendo da classe do objeto que está sendo operado.

//Quando a estrutura de objetos é fixa ou não muda frequentemente, mas você quer ser capaz de definir novas operações sobre a estrutura.

//No entanto, este padrão tem uma desvantagem significativa: se a estrutura de objetos mudar (por exemplo, se novas classes de objetos forem adicionadas),
//todas as classes de visitante precisarão ser alteradas para acomodar as novas classes.

var entityHos = new IEntityHOS[] { new Product() { Id = 1, Description = "Product test"}, new Consumer() { Id = 1, Name = "Consumer teste"} };

var visitor = new PrintVisitor();

foreach (IEntityHOS entity in entityHos)
{
    entity.Accept(visitor);
}

interface IEntityHOS
{
    void Accept(IEntityHOSVisitor visitor);
}

class Product : IEntityHOS
{
    public int Id { get; set; }
    public string Description { get; set; } = default!;
    

    public void Accept(IEntityHOSVisitor visitor)
    {
        visitor.Visit(this);
    }
}

class Consumer : IEntityHOS
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    

    public void Accept(IEntityHOSVisitor visitor)
    {
        visitor.Visit(this);
    }
}

interface IEntityHOSVisitor
{
    void Visit(Product product);
    void Visit(Consumer product);
}

class PrintVisitor : IEntityHOSVisitor
{
    public void Visit(Product product)
    {
        Console.WriteLine(product.Description);
    }

    public void Visit(Consumer consumer)
    {
        Console.WriteLine(consumer.Name);
    }
}