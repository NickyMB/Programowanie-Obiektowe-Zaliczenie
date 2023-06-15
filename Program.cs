// Autorzy: Michał Grochowski , Mikołaj Bacior , Kasia Adrianowicz
using Bibiotekav2;
namespace Bibiotekav2
{
    internal class Program
    {
        //wyświetlanie autorów i przejście do nawigacji
        public static void Main()
        {
            Console.Title = "Twoja Biblioteka";
            Console.Clear();
            Console.WriteLine("██╗     ██╗██████╗ ██████╗ ██╗███████╗██╗   ██╗\n" +
                             "██║     ██║██╔══██╗██╔══██╗██║██╔════╝╚██╗ ██╔╝\n" +
                             "██║     ██║██████╔╝██████╔╝██║█████╗   ╚████╔╝ \n" +
                             "██║     ██║██╔══██╗██╔══██╗██║██╔══╝    ╚██╔╝  \n" +
                             "███████╗██║██████╔╝██║  ██║██║██║        ██║   \n" +
                             "╚══════╝╚═╝╚═════╝ ╚═╝  ╚═╝╚═╝╚═╝        ╚═╝   ");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine(@"
 _                    o 
|_|   _|_ _  __ _  \/   
| ||_| |_(_) |  /_ /  o ");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine(@"
                      __                           
|V| o  _ |_  _  |    /__ __ _  _ |_  _     _  |  o 
| | | (_ | |(_| |    \_| | (_)(_ | |(_)\^/_>  |< | ");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine(@"
                    o     _                
|V| o  |   _  |  _  |    |_) _  _  o  _  __
| | |  |< (_) | (_|_|    |_)(_|(_  | (_) | ");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine(@"
                               _                               
|/  _ _|_ _  __ _  \/__  _    |_| _| __ o  _ __  _     o  _  _ 
|\ (_| |_(_| |  /_ / | |(_|   | |(_| |  | (_|| |(_)\^/ | (_  /_
");
            Thread.Sleep(1500);
            Console.Clear();
            Fetches.Fetch();
            Library.ReadFromFile();
            Loging.LoginNav();
        }
    }
}