﻿using System;
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
                // Box.Border(Navigate.Books);
                Box.Border(Navigate.Books_Admin);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        ShowLibrary();
                        break;
                    case ConsoleKey.D2:
                        text;
                        ShowAuthors();
                        break;
                    case ConsoleKey.D3:
                        SearchBookbByTitle();
                        break;
                    case ConsoleKey.D4:
                        SearchBookbByAuthor();
                        break;
                    case ConsoleKey.D5:
                        ShowUnavailable();
                        break;
                    case ConsoleKey.D6:
                        /* if (== admim)
                            ShowUnavailable();
                        else
                            continue; */
                        break;
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
                    Console.WriteLine($"{book.Title} {" | "} {book.Author}");
                }
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
                    Console.WriteLine($"{book.Title} {" | "} {book.Author}");
                }
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
                    Console.WriteLine($"\n{book.Title} {" | "} {book.Author}");
                else
                    continue;
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
                    Console.WriteLine($"\n{book.Title} {" | "} {book.Author}");
                }
            }
        }
        public static void ReadFromFile()
        {
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
                        string title = elements[0].Trim();
                        string author = elements[1].Trim();
                        string isbnNumber = Convert.ToString(elements[2].Trim());
                        string publisher = elements[3].Trim();
                        string publicationYear = Convert.ToString(elements[4].Trim());
                        string category = elements[5].Trim();
                        bool available = Convert.ToBoolean(elements[6].Trim());

                        Book book = new Book(title, author, isbnNumber, publisher, publicationYear, category, available);
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