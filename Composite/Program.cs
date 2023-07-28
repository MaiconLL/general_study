
//O padrão de design Composite é um padrão de design estrutural que permite compor objetos em estruturas de árvore
//e trabalhar com essas estruturas como se fossem objetos individuais.

//Esse padrão é útil quando você precisa trabalhar com estruturas que podem ser recursivas na natureza
//(como arquivos e pastas, gráficos de objetos, ou até mesmo operações matemáticas).


//Casos de uso comuns para o padrão Composite incluem:

//Representação de hierarquias de objetos: O padrão Composite permite que você crie uma hierarquia de objetos com uma estrutura em árvore.
//Por exemplo, você pode usar este padrão para representar um sistema de arquivos com pastas (que podem conter outras pastas ou arquivos) e arquivos individuais.

//Quando você quer tratar objetos compostos e individuais de maneira uniforme: O padrão Composite permite que você trabalhe com objetos compostos
//e individuais de maneira uniforme. Por exemplo, você pode ter uma operação Draw() que funciona tanto para objetos individuais como para grupos de objetos.

//Para simplificar código complexo: O padrão Composite pode tornar o código que trabalha com estruturas complexas mais simples e fácil de entender,
//escondendo a complexidade dentro de classes compostas.

using System.Diagnostics;

Folder folderNormal = new DesktopFolder() { Name = @"c:\mercfarma"};
Folder folderFTP = new FtpFolder(new FtpProvider());

Folder grupo = new FolderGroup();
grupo.AddFolder(folderNormal);
grupo.AddFolder(folderFTP);

grupo.OpenFolder();

abstract class Folder
{
    public string Name { get; set; } = default!;

    public virtual void AddFolder(Folder folder)
    {
        throw new NotImplementedException();
    }

    public virtual void RemoveFolder(Folder folder)
    {
        throw new NotImplementedException();
    }

    public virtual void OpenFolder()
    {
        throw new NotImplementedException();
    }

    public virtual string[] GetPaths()
    {
        throw new NotImplementedException();
    }
}

class DesktopFolder : Folder
{
    public override void OpenFolder()
    {
        Process.Start(Name);
    }
}

class FtpFolder : Folder
{
    private readonly IFtpProvider _ftpProvider;
    public FtpFolder(IFtpProvider ftpProvider)
    {
        _ftpProvider = ftpProvider;
    }
    public override void OpenFolder()
    {
        _ftpProvider.OpenFolder(Name);
    }
}

class FolderGroup : Folder
{
    private readonly List<Folder> _folder = new List<Folder>();

    public override void OpenFolder()
    {
        foreach (var folder in _folder)
        {
            folder.OpenFolder();
        }
    }

    public override void AddFolder(Folder folder)
    {
        _folder.Add(folder);
    }

    public override void RemoveFolder(Folder folder)
    {
        _folder.Remove(folder);
    }
}

interface IFtpProvider
{
    void OpenFolder(string name);
}

class FtpProvider : IFtpProvider
{
    public void OpenFolder(string name)
    {
        //TO DO
        Console.WriteLine("OPen ftp");
    }
}