using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    public class Registration
    {
        private string Login;
        private string Password;

        public Registration(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public void CheckLogin()
        {
            NpgsqlConnection Connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");
            try
            {
                List<Userregistration> LoginUser = Connection.Query<Userregistration>($"SELECT * FROM \"Userregistration\" WHERE \"Login\" = '{Login}'").ToList();

                if (LoginUser.Count == 1)
                {
                    Console.WriteLine("Данный логин занят");

                }
                else if (string.IsNullOrEmpty(Login))
                {
                    Console.WriteLine("Логин не может быть пустым");
                }
                else
                {
                    Connection.Query($"Insert into \"Userregistration\" (\"Login\", \"Password\") values ('{Login}', '{Password}')");
                }
                Console.WriteLine("Вы успешно прошли регистрацию, перезапустите программу");
                Environment.Exit(0);
            }
            finally
            {
                Connection.Dispose();
            }
        }

    }
}
