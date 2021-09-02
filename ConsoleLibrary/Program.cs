using Npgsql;
using System;

namespace ConsoleLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            NpgsqlConnection connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");
            try
            {

                Console.WriteLine("1. Регистрация");
                Console.WriteLine("2. Вход");
                string Choice1 = Console.ReadLine();
                int Choice = Convert.ToInt32(Choice1);
                if (Choice == 1)
                {
                    Console.WriteLine("Введите новый логин");
                    string LoginRegistr = Console.ReadLine();
                    Console.WriteLine("Введите новый пароль");
                    string PasswordRegistr = Console.ReadLine();
                    Registration registration = new Registration(LoginRegistr, PasswordRegistr);
                    registration.CheckLogin();
                }
                else
                {
                    Console.WriteLine("Введите Логин");
                    string Login = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string Password = Console.ReadLine();
                    Authorization authorization = new Authorization(Login, Password);
                    authorization.ComeIn();
                    Console.WriteLine($"Добро пожаловать {Login}");
                }
                while (true)
                {
                    Console.WriteLine("1.\t Список книг");
                    Console.WriteLine("2.\t Добавить кнгу");
                    Console.WriteLine("3.\t Выдать книгу студенту");
                    Console.WriteLine("4.\t Принять книгу у студента");
                    string Choice2 = Console.ReadLine();
                    int Choice3 = Convert.ToInt32(Choice2);
                    if (Choice3 == 1)
                    {
                        ActionsLibrary.ListBooks();
                    }
                    if (Choice3 == 2)
                    {
                        ActionsLibrary.AddBook();
                    }
                    if (Choice3 == 3)
                    {
                        ActionsLibrary.GiveBook();
                    }
                    if (Choice3 == 4)
                    {
                        ActionsLibrary.TakeBook();
                    }
                }
            }
            finally
            {
                connection.Dispose();
            }


        }
    }
}
