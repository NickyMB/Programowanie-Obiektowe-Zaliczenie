using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class Library
    {
        public static List<Book> booksList = new List<Book>(); //Lista z książkami
        //Główna nawigacja strony Pokaż książki
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
                        SearchBookbByISBN();
                        break;
                    case ConsoleKey.D5:
                        SearchBookbByTitle();
                        break;
                    case ConsoleKey.D6:
                        SearchBookbByAuthor();
                        break;
                    case ConsoleKey.D7:
                        SearchBookbByCategory();
                        break;
                    case ConsoleKey.D8:
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

                    case ConsoleKey.D9:
                        if (Loging.IsAdminLogged == true)
                        {
                            ShowLastReturns();
                            break;
                        }
                        else
                        {
                            BooksActions.ReturnMyBooks();
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
        // Pokazywanie wszystkich dostępnych książek
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
        // Wyświetlanie użytkowników
        public static void PrintUsernames()
        {
            Dictionary<string, string> users = Loging.GetUsers();
            Console.WriteLine("Lista urzytkowników:");
            foreach (var username in users.Keys)
            {
                Console.Write($"{username} :");
                foreach (var book in Library.booksList.Where(x => x.Borrower == username))
                {
                    Console.Write($"{book.Title} |");
                }
                Console.WriteLine("");
            }
            Navigate.Navigation();
        }
        // Szukanie książek po numeże ISBN
        public static void SearchBookbByISBN()
        {
            List<Book> matchingBooks = new List<Book>();
            string searchISBN = Console.ReadLine();
            do
            {
                Console.WriteLine("Podaj numer ISBN szukanej książki:");
                searchISBN = Console.ReadLine();

                if (string.IsNullOrEmpty(searchISBN))
                {
                }
                else
                {
                    matchingBooks = booksList.Where(book => book.Title.IndexOf(searchISBN, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                }
            } while (string.IsNullOrEmpty(searchISBN));
            foreach (Book book in matchingBooks)
            {
                if (book.Available == true)
                    Console.WriteLine($"\n{book.NumberID} {" | "}  {book.ISBN_number}  {" | "}  {book.Title} {" | "} {book.Author}");
                else
                    continue;
            }
        }
        // Wyświetlanie Kategorii Książek
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
        // Wyświetlanie wszystkich Autorów
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
        // Pokazywanie wypożyczonych książek i osób które je wyporzyczyły
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
        // Pokazywanie ostatnio zwróconych książek
        public static void ShowLastReturns()
        {
            foreach (var book in Library.booksList.Where(x => x.Return_date != DateTime.Parse("01-01-0001 00:00:00")))
            {
                Console.WriteLine($"{book.Title} {" | "} {book.Borrower} {" | "} {book.Borrow_date} {" | "} {book.Return_date}");
            }
        }
        // Szukanie książki po tytule
        public static void SearchBookbByTitle()
        {
            List<Book> matchingBooks = new List<Book>();
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
        // Szukanie książki po Kategorii
        public static void SearchBookbByCategory()
        {
            bool check = true;
            string category;
            do
            {
                Console.WriteLine("Podaj nazwę kategorii:");
                category = Console.ReadLine();
                if (category != "")
                {
                    check = false;
                }

            } while (check);

            foreach (var book in Library.booksList.Where(x => x.Category == category))
            {
                Console.WriteLine($"{book.NumberID} {book.Title}");
            }
        }
        // Szukanie książki po autorze
        public static void SearchBookbByAuthor()
        {
            List<Book> matchingBooks = new List<Book>();
            string searchName;
            do
            {
                bool check = true;
                do
                {
                    Console.WriteLine("Podaj imię autora do wyszukania:");
                    searchName = Console.ReadLine();
                    if (searchName != "")
                    {
                        check = false;
                    }

                } while (check);

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
        // Odczyt książek z pliku
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
                        //Console.WriteLine("Niepoprawny format: " + line);
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