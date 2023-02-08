// See https://aka.ms/new-console-template for more information
using Blog;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

internal class Program
{
    private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
    private static void Main(string[] args)
    {
        Database.Connection = new SqlConnection(CONNECTION_STRING);
        using (Database.Connection)
        {

            // createCategory(Database.Connection);
            createUserRole(Database.Connection);
            // createPost(Database.Connection);
            // Load();
            // Console.ReadKey();
        }
    }

    static void createUserRole(SqlConnection connection)
    {
        var userRole = new UserRole()
        {
            UserId = 1,
            RoleId = 1
        };

        var repository = new Repository<UserRole>(connection);
        repository.Create(userRole);
    }

    static void createCategory(SqlConnection connection)
    {
        var category = new Category()
        {
            Name = "Desenvolvedor C# .Net",
            Slug = "desenvolvedor-C#"
        };

        var repository = new Repository<Category>(connection);
        repository.Create(category);
    }

    static void createPost(SqlConnection connection)
    {
        var post = new Post()
        {
            AuthorId = 1,
            CategoryId = 1,
            Body = "Criador de conteúdos C#",
            Slug = "post-mobile",
            Summary = "Especialista em conteúdos C#",
            Title = "Desenvolvimento C#"
        };
        var repository = new Repository<Post>(connection);
        repository.Create(post);
    }
    private static void Load()
    {
        Console.Clear();
        Console.WriteLine("Meu Blog");
        Console.WriteLine("---------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Gestão de usuários");
        Console.WriteLine("2 - Gestão de perfil");
        Console.WriteLine("3 - Gestão de categoria");
        Console.WriteLine("4 - Gestão de tag");
        Console.WriteLine("5 - Vincular perfil/usuário");
        Console.WriteLine("6 - Vincular post/tag");
        Console.WriteLine("7 - Relatórios");
        Console.WriteLine();
        Console.WriteLine();
        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            // case 1:
            //     ListTagScreen.Load();
            //     break;
            // case 2:
            //     CreateTagScreen.Load();
            //     break;
            // case 3:
            //     UpdateTagScreen.Load();
            //     break;
            case 4:
                MenuTagScreen.Load();
                break;
            default: Load(); break;
        }
    }
}