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
        static public void RegistrationPerson()
        {
            bool successfulRegistration = false;
            while (successfulRegistration == false)
            {
                Console.WriteLine("Введите новый логин");
                string LoginRegistr = Console.ReadLine();
                Console.WriteLine("Введите новый пароль");
                string PasswordRegistr = Console.ReadLine();
                Registration registration = new Registration(LoginRegistr, PasswordRegistr);
                successfulRegistration = registration.CheckLogin();
            }
        }
        public bool CheckLogin()
        {
            NpgsqlConnection Connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");
            try
            {
                bool checkName = false;
                List<Userregistration> LoginUser = Connection.Query<Userregistration>($"SELECT * FROM \"Userregistration\" WHERE \"Login\" = '{Login}'").ToList();

                if (LoginUser.Count == 0)
                {
                    Connection.Query($"Insert into \"Userregistration\" (\"Login\", \"Password\") values ('{Login}', '{Password}')");
                    Console.WriteLine("Вы успешно прошли регистрацию");
                    checkName = true;
                    return checkName;
                }
                else if (LoginUser.Count == 1)
                {
                    Console.WriteLine("Данный логин занят");
                    return checkName;
                }
                else if(string.IsNullOrEmpty(Login))
                {
                    Console.WriteLine("Логин не может быть пустым");
                    return checkName;
                }
                return checkName;
            }

            finally
            {
                Connection.Dispose();
            }
        }
    }

}
