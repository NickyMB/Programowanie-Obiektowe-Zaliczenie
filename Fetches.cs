using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class Fetches
    {
        public static void Fetch()
        {
            string url = "https://gist.githubusercontent.com/NickyMB/b26c256dcebbeef8f881f37111682899/raw/98ea7a29383324e89e72a5483f1a5bdc97418fa2/books.txt";
            string filePath = "books.txt";

            try
            {
                using (WebClient client = new WebClient())
                {
                    string data = client.DownloadString(url);
                    File.WriteAllText(filePath, data);
                    Console.WriteLine("Data fetched and saved successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
