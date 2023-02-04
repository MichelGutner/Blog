// See https://aka.ms/new-console-template for more information
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

internal class Program
{
    private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
    private static void Main(string[] args)
    {
        var connection = new SqlConnection(CONNECTION_STRING);
        using (connection)
        {
            ReadUsers(connection);
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            // DeleteUser();
        }


        static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.GetUsers();
            foreach (var user in users)
                Console.WriteLine(user.Name);
        }

        static void ReadUser()
        {

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);

                Console.WriteLine(user.Name);
            }
        }

        static void CreateUser()
        {
            var user = new User()
            {
                Name = "Gabriella Augusto Micheletti",
                Email = "gabriella@gmail.com",
                PasswordHash = "123456",
                Bio = "Esposa do Michel",
                Image = "http://",
                Slug = "gabi-micheletti"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
        }

        static void UpdateUser()
        {
            var user = new User()
            {
                Id = 2,
                Name = "Gabriella Micheletti",
                Email = "gabriella_micheletti@gmail.com",
                PasswordHash = "123456",
                Bio = "Estudante de Tecnologia,",
                Image = "http://",
                Slug = "gabi-micheletti"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);
                Console.WriteLine("Cadastro atualizado com sucesso!");
            }
        }

        static void DeleteUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);
                connection.Delete<User>(user);
                Console.WriteLine("Cadastro excluído com sucesso!");
            }
        }
    }
}