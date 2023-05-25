﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class Navigate
    {
        //Nawigacje:
        public static string[] MainNav = { "1 - Pokaż Menu", "2 - Pokaż książki", "3 - Zaloguj się", "4 - Menu item4", "5 - Menu item5", "Q - Exit" };
        public static string[] Login = { "1 - Register", "2 - Login", "Q - Exit" };
        public static string[] Books = { "1 - Pokaż książki", "2 - Pokaż autorów", "Q - Exit" };

        public static void Navigation()
        {
            Console.Clear();
            Box.Border(Navigate.MainNav);
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Odczytaj wciśnięty klawisz
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Box.Border(Navigate.MainNav);
                        break;
                    case ConsoleKey.D2:
                        Loging.LoginPanel();
                        break;
                    case ConsoleKey.D3:
                        Box.Border(Navigate.Books);
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wybrano nieobsługiwany klawisz.");
                        break;
                }
            }
        }

    }
}