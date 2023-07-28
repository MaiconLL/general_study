

//Iterator é um padrão de design comportamental que permite percorrer elementos de uma coleção sem expor sua implementação subjacente.
//O Iterator fornece uma maneira de acessar os elementos de um objeto agregado sequencialmente sem expor sua representação subjacente.

//Casos de uso:

//O padrão Iterator é muito útil quando a estrutura de dados é complexa e queremos fornecer uma maneira de percorrê-la sem expor a implementação.
//Isso é comumente usado em listas, árvores, tabelas de hash, etc.

//As coleções do .NET Framework, por exemplo, utilizam o padrão Iterator através das interfaces IEnumerable e IEnumerator.

//Além disso, ele é especialmente útil quando se trabalha com diferentes tipos de coleções e se deseja usar uma abordagem uniforme para iterar sobre elas.


ListaConcreta colecao = new ListaConcreta();
colecao[0] = "Item 1";
colecao[1] = "Item 2";
colecao[2] = "Item 3";

// Obtendo o iterator
IIterator iterator = colecao.GetIterator();

// Iterando pelos elementos
object item = iterator.Primeiro();
while (item != null)
{
    Console.WriteLine(item);
    item = iterator.Proximo();
}

// Removendo o último elemento
iterator.Remover();

// Iterando novamente para mostrar que o último elemento foi removido
iterator = colecao.GetIterator();
item = iterator.Primeiro();
while (item != null)
{
    Console.WriteLine(item);
    item = iterator.Proximo();
}


interface IIterator
{
    object Primeiro();
    object Proximo();
    bool TemProximo();
    object Atual();
    void Remover();
}


interface ILista
{
    IIterator GetIterator();
}

class ListaConcreta : ILista
{
    List<object> items = new List<object>();

    public IIterator GetIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Contagem
    {
        get { return items.Count; }
    }

    public object this[int index]
    {
        get { return items[index]; }
        set { items.Insert(index, value); }
    }

    public void Remover(int index)
    {
        items.RemoveAt(index);
    }
}

class ConcreteIterator : IIterator
{
    private ListaConcreta lista;
    private int index;

    public ConcreteIterator(ListaConcreta aggregate)
    {
        this.lista = aggregate;
    }

    public object Primeiro()
    {
        return lista[0];
    }

    public object Proximo()
    {
        object ret = default!;
        if (index < lista.Contagem - 1)
        {
            ret = lista[++index];
        }

        return ret;
    }

    public bool TemProximo()
    {
        return index < lista.Contagem;
    }

    public object Atual()
    {
        return lista[index];
    }

    public void Remover()
    {
        lista.Remover(index);
    }
}
