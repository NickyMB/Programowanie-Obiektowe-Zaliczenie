﻿using Bibiotekav2;
namespace Bibiotekav2
{
    internal class Program
    {
        public static void Main()
        {
            Console.Title = "Twoja Biblioteka";
            Console.Clear();
            List<int> borowersNumber = new List<int>();
            borowersNumber.Add(500);
            {
                int borowerNumber = Borrower.GenerateBorrowerNumber();
                borowersNumber.Add(borowerNumber);
                //Console.WriteLine("Generated number is : " + borowerNumber);
                Navigate.Navigation();
                Console.ReadKey();
            }
        }

    }
}

