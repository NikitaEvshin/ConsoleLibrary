using Npgsql;
using System;

namespace ConsoleLibrary
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("1. Регистрация");
            Console.WriteLine("2. Вход");
            string selectedAuthentificationOptionst = Console.ReadLine();
            int selectedAuthentificationOption = Convert.ToInt32(selectedAuthentificationOptionst);
            if (selectedAuthentificationOption == 1)
            {
                Registration.RegistrationPerson();
            }
            else
            {
                Authorization.AuthorizationPerson();
            }
            LibraryActions.ChoceActionsInLibrary();
        }
    }
}

