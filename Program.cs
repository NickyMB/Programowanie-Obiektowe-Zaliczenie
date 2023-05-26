using Bibiotekav2;
namespace Bibiotekav2
{
    internal class Program
    {
        public static void Main()
        {
            Console.Title = "Twoja Biblioteka";
            Console.Clear();
            Fetches.Fetch();
            Library.ReadFromFile();
            Loging.LoginNav();
        }
    }
}

