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
            ReadRoles(connection);
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

        static void ReadRoles(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var roles = repository.GetRoles();
            foreach(var role in roles)
                Console.WriteLine(role.Name);
        }
    
    }
}