using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    public class ActionsLibrary
    {

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
