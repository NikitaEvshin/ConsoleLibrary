using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    public class Authorization
    {
        public string Login;
        private string Password;
        public Authorization(string login, string password)
        {
            Login = login;
            Password = password;
        }
       static public void AuthorizationPerson()
        {
            Console.WriteLine("Введите Логин");
            string Login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string Password = Console.ReadLine();
            Authorization authorization = new Authorization(Login, Password);
            authorization.ComeIn();
            Console.WriteLine($"Добро пожаловать {Login}");
        }
        public void ComeIn()
        {
            NpgsqlConnection Connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");
            try
            {
                List<Userregistration> LoginUser = Connection.Query<Userregistration>($"SELECT * FROM \"Userregistration\" WHERE \"Login\"  = '{Login}' AND  \"Password\" = '{Password}'").ToList();
                if (LoginUser.Count == 1)
                {
                    Console.WriteLine("Вы успешно авторизовались");
                }
                else
                {
                    Console.WriteLine("Ошибка авторизации");
                    Console.WriteLine("Логин или пароль неверные");
                    Environment.Exit(0);
                }
            }
            finally
            {
                Connection.Dispose();
            }
        }
    }
}
