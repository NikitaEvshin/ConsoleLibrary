using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    public class LibraryActions
    {

        static public void ChoceActionsInLibrary()
        {
            while (true)
            {
                Console.WriteLine("1.\t Список книг");
                Console.WriteLine("2.\t Добавить кнгу");
                Console.WriteLine("3.\t Выдать книгу студенту");
                Console.WriteLine("4.\t Принять книгу у студента");
                string selectedCommandst = Console.ReadLine();
                int selectedCommand = Convert.ToInt32(selectedCommandst);
                if (selectedCommand == 1)
                {
                    LibraryActions.ListBooks();
                }
                if (selectedCommand == 2)
                {
                    LibraryActions.AddBook();
                }
                if (selectedCommand == 3)
                {
                    LibraryActions.GiveBook();
                }
                if (selectedCommand == 4)
                {
                    LibraryActions.TakeBook();
                }
            }
        }
        static public void ListBooks()
        {
            NpgsqlConnection Connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");
            try
            {
                List<LibraryBook> ListBook = Connection.Query<LibraryBook>($"SELECT * FROM \"LibraryBooks\"").ToList();
                foreach (LibraryBook i in ListBook)
                {
                    Console.WriteLine(i);
                }
            }
            finally
            {
                Connection.Dispose();
            }
        }
        static public void AddBook()
        {
            NpgsqlConnection connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");
            try
            {
                Console.WriteLine("Введите автора книги");
                string author = Console.ReadLine();
                Console.WriteLine("Введите название книги");
                string nameBook = Console.ReadLine();
                connection.Query($"Insert into \"LibraryBooks\" (\"Author\", \"NameBook\", \"IsTaked\", \"StudentName\") values ('{author}', '{nameBook}', '{false}', '{0}')");
                Console.WriteLine("Книга успешно добавлена");
            }
            finally
            {
                connection.Dispose();
            }
        }
        static public void GiveBook()
        {
            NpgsqlConnection connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");
            try
            {
                Console.WriteLine("Введите автора книги");
                string author = Console.ReadLine();
                Console.WriteLine("Введите название книги");
                string nameBook = Console.ReadLine();
                Console.WriteLine("Введите имя студента");
                string studentName = Console.ReadLine(); 
                connection.Query($"update \"LibraryBooks\" set \"IsTaked\" = '{true}', \"StudentName\" = '{studentName}' where \"Author\" = '{author}' and \"NameBook\" = '{nameBook}'"); ;
            }
            finally
            {
                connection.Dispose();
            }
        }
        static public void TakeBook()
        {
            NpgsqlConnection connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");
            try
            {
                Console.WriteLine("Введите автора книги");
                string author = Console.ReadLine();
                Console.WriteLine("Введите название книги");
                string nameBook = Console.ReadLine();
                connection.Query($"update \"LibraryBooks\" set \"IsTaked\" = '{false}', \"StudentName\" = '{null}' where \"Author\" = '{author}' and \"NameBook\" = '{nameBook}' ");
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}
