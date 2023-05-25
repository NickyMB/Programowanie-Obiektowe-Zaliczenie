using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class Navigate
    {
        public static void Interface()
        {
            Console.Clear();
            // Definicje znaków do rysowania kwadratu
            int TerminalWidth = Console.WindowWidth / 2;
            int TerminalHeight = Console.WindowHeight / 2;

            const char KPG = '┐';
            const char KLG = '┌';
            const char KLD = '└';
            const char KPD = '┘';
            const char KPO = '─';
            const char KPI = '│';

            // Tekst do umieszczenia wewnątrz kwadratu
            string[] lines = { "1 - Pokaż Menu", "2 - Pokaż książki", "3 - Menu item3", "4 - Menu item4", "5 - Menu item5", "q - Exit" };

            // Rysowanie kwadratu
            Console.Write(KLG);
            for (int i = 0; i < TerminalWidth - 2; i++)
            {
                Console.Write(KPO);
            }
            Console.WriteLine(KPG);

            foreach (string line in lines)
            {
                Console.Write(KPI);
                Console.Write(line.PadRight(TerminalWidth - 2));
                Console.WriteLine(KPI);
            }

            Console.Write(KLD);
            for (int i = 0; i < TerminalWidth - 2; i++)
            {
                Console.Write(KPO);
            }
            Console.WriteLine(KPD);
            Navigation();
        }
        public static void Navigation()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Odczytaj wciśnięty klawisz

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Interface();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Wybrano klawisz 2. Wykonaj akcję 2.");
                        // Wykonaj akcję 2
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Wybrano klawisz 3. Wykonaj akcję 3.");
                        // Wykonaj akcję 3
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Wybrano klawisz 4. Wykonaj akcję 4.");
                        // Wykonaj akcję 4
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("Wybrano klawisz 5. Wykonaj akcję 5.");
                        // Wykonaj akcję 5
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
