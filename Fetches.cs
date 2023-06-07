using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class Fetches
    {
        public static void Fetch()
        {
            string url = "https://gist.githubusercontent.com/NickyMB/b26c256dcebbeef8f881f37111682899/raw/1fa0c2ffa755d6711136b0f5176d6b73890161f5/books.txt";
            string filePath = "books.txt";

            try
            {
                using (WebClient client = new WebClient())
                {
                    string data = client.DownloadString(url);
                    File.WriteAllText(filePath, data);

                }
            }
            catch (Exception ex)
            {
                string text = $"Mały Książe;Antoine de Saint-Exupéry;9783140464079;Wilga;2018-02-28;Literatura dziecięca;true\nMetro 2033;Dmitrij Gluchowski;9789491425004;Insignis;2015-11-04;Fantastyka postapokaliptyczna;true\r\nMetro 2034;Dmitrij Gluchowski;9782841725434;Insignis;2015-11-04;Fantastyka postapokaliptyczna;true\r\nMetro 2035;Dmitrij Gluchowski;9783453315556;Insignis;2015-11-04;Fantastyka postapokaliptyczna;true";
                try
                {
                    // Tworzenie i zapis do pliku
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(text);
                    }
                }
                catch (Exception ex2)
                {
                }
            }
        }
    }
}
