using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class Box
    {
        //Stwożenie ramki wokół nawigacji
        public static void Border(string[] names)
        {
            Random random = new Random();
            ConsoleColor randomColor = (ConsoleColor)random.Next(1, 16); // Generuje losowy kolor czcionki
            Console.ForegroundColor = randomColor;
            // Definicje znaków do rysowania kwadratu
            int TerminalWidth = Console.WindowWidth - 5;
            int TerminalHeight = Console.WindowHeight;

            const char KPG = '┐';
            const char KLG = '┌';
            const char KLD = '└';
            const char KPD = '┘';
            const char KPO = '─';
            const char KPI = '│';

            // Rysowanie kwadratu
            Console.Write(KLG);
            for (int i = 0; i < TerminalWidth - 2; i++)
            {
                Console.Write(KPO);
            }
            Console.WriteLine(KPG);
            foreach (string line in names)
            {

                if (line == "Q - Wyjście")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(KPI);
                    Console.Write(line.PadRight(TerminalWidth - 2));
                    Console.WriteLine(KPI);
                }
                else
                {
                    randomColor = (ConsoleColor)random.Next(1, 16); // Generuje losowy kolor czcionki
                    Console.ForegroundColor = randomColor;
                    Console.Write(KPI);
                    Console.Write(line.PadRight(TerminalWidth - 2));
                    Console.WriteLine(KPI);
                }
            }

            Console.Write(KLD);
            for (int i = 0; i < TerminalWidth - 2; i++)
            {
                Console.Write(KPO);
            }
            Console.WriteLine(KPD);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
