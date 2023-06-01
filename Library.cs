using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class Library
    {
        public static List<Book> booksList = new List<Book>();
        public static void Start()
        {
            while (true)
            {
                if (Loging.IsAdminLogged == true)
                    Box.Border(Navigate.Books_Admin);
                else
                    Box.Border(Navigate.Books);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        ShowLibrary();
                        break;
                    case ConsoleKey.D2:
                        ShowAuthors();
                        break;
                    case ConsoleKey.D3:
                        ShowCategories();
                        break;
                    case ConsoleKey.D4:
                        SearchBookbByTitle();
                        break;
                    case ConsoleKey.D5:
                        SearchBookbByAuthor();
                        break;
                    case ConsoleKey.D6:
                        SearchBookbByCategory();
                        break;
                    case ConsoleKey.D7:
                        if (Loging.IsAdminLogged == true)
                        {
                            ShowUnavailable();
                            break;
                        }
                        else
                        {
                            BooksActions.ShowMyBooks();
                            break;
                        }

                    case ConsoleKey.D8:
                        if (Loging.IsAdminLogged == true)
                        {
                            ShowLastReturns();
                            break;
                        }
                        else
                        {
                            BooksActions.PassMyBooks();
                            break;
                        }
                    case ConsoleKey.Q:
                        Navigate.Navigation();
                        break;
                    default:
                        Console.WriteLine("Niewłaściwy wybór, wybierz ponownie");
                        break;
                }
            }
        }
        public static void ShowLibrary()
        {
            foreach (Book book in booksList)
            {
                if (book.Available == true)
                {
                    Console.WriteLine($"{book.NumberID} {" | "} {book.Title} {" | "} {book.Author}");
                }
            }
        }
        public static void ShowCategories()
        {
            HashSet<string> uniqueCategories = new HashSet<string>();

            foreach (var book in booksList)
            {
                if (book.Available == true)
                {
                    uniqueCategories.Add(book.Category);
                }
            }

            foreach (var author in uniqueCategories)
            {
                Console.WriteLine(author);
            }
        }
        public static void ShowAuthors()
        {
            HashSet<string> uniqueAuthors = new HashSet<string>();

            foreach (var book in booksList)
            {
                if (book.Available == true)
                {
                    uniqueAuthors.Add(book.Author);
                }
            }

            foreach (var author in uniqueAuthors)
            {
                Console.WriteLine(author);
            }
        }
        public static void ShowUnavailable()
        {
            foreach (Book book in booksList)
            {
                if (book.Available == false)
                {
                    Console.WriteLine($"{book.Title} {" | "} {book.Borrower} {" | "} {book.Borrow_date}");
                }
            }
        }
        public static void ShowLastReturns()
        {
            foreach (var book in Library.booksList.Where(x => x.Borrower != null))
            {
                Console.WriteLine($"{book.Title} {" | "} {book.Borrower} {" | "} {book.Borrow_date} {" | "} {book.Return_date}");
            }
        }
        public static void SearchBookbByTitle()
        {
            List<Book> matchingBooks = new List<Book>();
            Console.WriteLine("Podaj tytuł szukanej książki:");
            string searchName = Console.ReadLine();
            do
            {
                Console.WriteLine("Podaj tytuł szukanej książki:");
                searchName = Console.ReadLine();

                if (string.IsNullOrEmpty(searchName))
                {
                }
                else
                {
                    matchingBooks = booksList.Where(book => book.Title.IndexOf(searchName, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                }
            } while (string.IsNullOrEmpty(searchName));
            foreach (Book book in matchingBooks)
            {
                if (book.Available == true)
                    Console.WriteLine($"\n{book.NumberID} {" | "}  {book.Title} {" | "} {book.Author}");
                else
                    continue;
            }
        }
        public static void SearchBookbByCategory()
        {
            Console.WriteLine("Podaj nazwę kategorii");
            string category= Console.ReadLine();
            foreach (var book in Library.booksList.Where(x => x.Category == category))
            {
                Console.WriteLine($"{book.NumberID} {book.Title}");
            }
        }
        public static void SearchBookbByAuthor()
        {
            List<Book> matchingBooks = new List<Book>();
            string searchName;
            do
            {
                Console.WriteLine("Podaj imię autora do wyszukania:");
                searchName = Console.ReadLine();
                if (string.IsNullOrEmpty(searchName))
                {
                }
                else
                {
                    matchingBooks = booksList.Where(book => book.Author.IndexOf(searchName, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                }
            } while (string.IsNullOrEmpty(searchName));
            foreach (Book book in matchingBooks)
            {
                if (book.Available == true)
                {
                    Console.WriteLine($"\n{book.NumberID} {" | "}  {book.Title} {" | "} {book.Author}");
                }
            }
        }
        public static void ReadFromFile()
        {
            int number = 0;
            string filePath = "books.txt";
            try
            {
                string fileContents = File.ReadAllText(filePath);
                string[] lines = fileContents.Split('\n');

                foreach (string line in lines)
                {
                    string[] elements = line.Split(';');

                    if (elements.Length == 7)
                    {
                        number = booksList.Count + 1;
                        string title = elements[0].Trim();
                        string author = elements[1].Trim();
                        string isbnNumber = Convert.ToString(elements[2].Trim());
                        string publisher = elements[3].Trim();
                        string publicationYear = Convert.ToString(elements[4].Trim());
                        string category = elements[5].Trim();
                        bool available = Convert.ToBoolean(elements[6].Trim());

                        Book book = new Book(number, title, author, isbnNumber, publisher, publicationYear, category, available);
                        booksList.Add(book);
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawny format: " + line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Błąd czytania pliku: " + e.Message);
            }
        }
    }
}