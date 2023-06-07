using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class BooksActions
    {
        // Porzyczanie książek
        public static void BorrowBooks()
        {
            string number = "";
            do
            {

                Console.WriteLine("Podaj Id Książki");
                number = Console.ReadLine();

            } while (string.IsNullOrEmpty(number));
            foreach (var book in Library.booksList.Where(x => x.NumberID == Convert.ToInt32(number)))
            {
                if (book.Available == true)
                {
                    Console.WriteLine($"Wyporzyczyłeś książkę {book.Title}");
                    book.Available = false;
                    book.Borrower = Loging.username;
                    book.Borrow_date = DateTime.Now;
                    book.Return_date = DateTime.Parse("01-01-0001 00:00:00");
                }
                else
                {
                    Console.WriteLine($"Książka {book.Title} została już wyporzyczona wybierz inną");
                }
            }
            Console.WriteLine("Poczekaj na wykonanie akcji");
            Thread.Sleep(1500);
            Navigate.Navigation();
        }
        // Pokazywanie książek użytkownika
        public static void ShowMyBooks()
        {
            foreach (var book in Library.booksList.Where(x => x.Borrower == Loging.username))
            {
                Console.WriteLine("Twoje Książki to:");
                Console.WriteLine($"{book.Title} {" Data wyporzyczenia: "} {book.Borrow_date}");
            }
        }
        //Zwracanie książek
        public static void ReturnMyBooks()
        {
            foreach (var book in Library.booksList.Where(x => x.Borrower == Loging.username))
            {
                Console.WriteLine("Twoje Książki to:");
                Console.WriteLine($"{book.NumberID} {book.Title}");
            }
            string number = "";
            do
            {

                Console.WriteLine("Podaj Id Książki");
                number = Console.ReadLine();

            } while (string.IsNullOrEmpty(number));
            foreach (var book in Library.booksList.Where(x => x.NumberID == Convert.ToInt32(number)))
            {
                book.Available = true;
                book.Borrower = "";
                book.Return_date = DateTime.Now;
            }
        }
    }
}
