using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class Loging
    {
        public static void LoginPanel()
        {
            Console.WriteLine("Welcome to the Loggin and Register panel.");
            while (true)
            {
                Box.Border(Navigate.Login);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Odczytaj wciśnięty klawisz

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        // Register.Register();
                        break;
                    case ConsoleKey.D2:
                        // Login.Login();
                        break;
                    case ConsoleKey.Q:
                        Navigate.Navigation();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

            }
        }
        /*
                static void Register()
                {
                    Console.WriteLine("\n--- Register ---");
                    Console.WriteLine("\nPlease enter your username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("\nPlease enter your password: ");
                    string password = Console.ReadLine();

                    // sprawdzanie czy uzytkownik istnieje ???!?!?!
                    if (UserExists(username))
                    {
                        Console.WriteLine("\nUser already exists, please try again with different username or jump to login section.");
                        return;
                    }
                    // przechowywanie danych uzytkownika w pliku tekstowym
                    using (StreamWriter sw = File.AppendText("users.txt"))
                    {
                        sw.WriteLine(username + "," + password);
                    }
                    Console.WriteLine("\nUser registered successfully.");

                }

                static void Login()
                {
                    Console.WriteLine("\n--- Login ---");
                    Console.WriteLine("\nPlease enter your username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("\nPlease enter your password: ");
                    string password = Console.ReadLine();

                    // sprawdzanie czy uzytkownik istnieje
                    if (!UserExists(username))
                    {
                        Console.WriteLine("\nUser does not exist! Please jump to register section first.");
                        return;
                    }
                    // sprawdzanie czy haslo jest poprawne
                    if (ValidateCredentials(username, password))
                    {
                        Console.WriteLine("\nUser logged in successfully.");
                        Console.WriteLine("\nWelcome " + username + "!");
                        // przekierowanie do panelu uzytkownika
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!

                        // UserPanel.UserPanel();

                        //!!!!!!!!!!!!!!!!!!!!!!!!!!
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid credentials, please try again.");
                    }
                }
        */
    }
}