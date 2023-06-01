using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class Navigate
    {
        //Nawigacje:
        public static string[] MainNav = { "1 - Zaloguj się", "2 - Pokaż książki", "3 - Wypożycz książki", "Q - Wyjście" };
        public static string[] Main_Admin = { "1 - Zaloguj się", "2 - Pokaż książki", "Q - Wyjście" };
        public static string[] Login = { "1 - Rejestracja", "2 - Logowanie", "Q - Wyjście" };
        public static string[] Books = { "1 - Lista książek", "2 - Lista autorów","3 - Pokaż kategorie","4 - Wyszukaj książkę po numeże ISBN" ,"5 - Wyszukaj książkę po tytule", "6 - Wyszukaj książkę po autorze", "7 - Wyszukaj książkę po kategorii","8 - Moje książki", "9 - Oddaj książki", "Q - Wyjście" };
        public static string[] Books_Admin = { "1 - Lista książek", "2 - Lista autorów", "3 - Pokaż kategorie", "4 - Wyszukaj książkę po numeże ISBN", "5 - Wyszukaj książkę po tytule", "6 - Wyszukaj książkę po autorze", "7 - Wyszukaj książkę po kategorii", "8 - Pokaż niedostępne książki", "9 - Pokaż ostatnio oddane książki", "Q - Wyjście" };

        public static void Navigation()
        {
            Console.Clear();


            if (Loging.IsAdminLogged == true)
                Box.Border(Navigate.Main_Admin);
            else
                Box.Border(Navigate.MainNav);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Odczytaj wciśnięty klawisz
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Loging.LoginNav();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Library.Start();
                        break;
                    case ConsoleKey.D3:
                        if (Loging.IsAdminLogged == true)
                        {
                            Console.WriteLine("Ups! Spróbuj ponownie z większą precyzją :)");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            BooksActions.BorrowBooks();
                            break;
                        }
                    case ConsoleKey.Q:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ups! Spróbuj ponownie z większą precyzją :)");
                        break;
                }
            }
        }
    }
}
