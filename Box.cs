using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class Box
    {
        public static void Border(string[] names)
        {
            Console.Clear();
            // Definicje znaków do rysowania kwadratu
            int TerminalWidth = Console.WindowWidth;
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
        }
    }
}
