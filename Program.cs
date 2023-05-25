using Bibiotekav2;
namespace Bibiotekav2
{
    internal class Program
    {
        public static void Main()
        {
            List<int> borowersNumber = new List<int>();
            borowersNumber.Add(500);
            {
                Console.Title = "Twoja Biblioteka";

                int borowerNumber = Borrower.GenerateBorrowerNumber();
                borowersNumber.Add(borowerNumber);
                //Console.WriteLine("Generated number is : " + borowerNumber);
                Navigation();
                Console.ReadKey();

            }
        }
        public static void Navigation()
        {
            int TerminalWidth = Console.WindowWidth/2;
            int TerminalHeight = Console.WindowHeight/2;
            bool isLeftAligned = false;
            const char KLG = '┌';
            const char KPG = '┐';
            const char KLD = '└';
            const char KPD = '┘';
            const char KLLS = '├';
            const char KLPS = '┤';
            const char KPO = '─';
            const char KPI = '│';
            int TotalWidth = 120;
            int Count = TerminalWidth - 2;
            int WysokoscTabeli = TerminalHeight;
            int Count2 = (TotalWidth - (Count + 2)) / 2;

            if (isLeftAligned == true)
            {
                Count2 = 0;
            }

            string Space = new string(' ', Count2);
            string line = new string(KPO, Count);

            Console.WriteLine(Space + KLG + line + KPG);
            line = new string(' ', Count);

            for (int i = 0; i < TerminalHeight; i++)
            {
                if (i == (int)(TerminalHeight / 2))
                {
                    
                }
                else
                {
                    Console.WriteLine(Space + KPI + line + KPI);
                }
            }

            line = new string(KPO, Count);
            Console.WriteLine(Space + KLD + line + KPD);
        }


    }
}

