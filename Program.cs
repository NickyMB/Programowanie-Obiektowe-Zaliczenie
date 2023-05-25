using Bibiotekav2;
namespace Bibiotekav2
{
    internal class Program
    {
        public static void Main()
        {
            List<int> borowersNumber = new List<int>();
            borowersNumber.Add(500);
            //for (int i = 0; i < borowersNumber; i++)
            {
                int borowerNumber = Borrower.GenerateBorrowerNumber();
                borowersNumber.Add(borowerNumber);
                Console.WriteLine("Generated number is : " + borowerNumber);
            }
        }
    }
}

