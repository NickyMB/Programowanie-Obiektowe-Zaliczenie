using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{
    internal class BooksActions
    {
        public static void BorrowBooks()
        {
            Console.WriteLine("Podaj Id Książki");
            int number = Convert.ToInt32(Console.ReadLine());
            foreach (var book in Library.booksList.Where(x => x.NumberID == number))
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
            Thread.Sleep(1500);
            Navigate.Navigation();
        }
        public static void ShowMyBooks()
        {
            foreach (var book in Library.booksList.Where(x => x.Borrower == Loging.username))
            {
                Console.WriteLine("Twoje Książki to:");
                Console.WriteLine($"{book.Title} {" Data wyporzyczenia: "} {book.Borrow_date}");
            }
        }
        public static void PassMyBooks()
        {
            foreach (var book in Library.booksList.Where(x => x.Borrower == Loging.username))
            {
                Console.WriteLine("Twoje Książki to:");
                Console.WriteLine($"{book.NumberID} {book.Title}");
            }
            Console.Write("Podaj id książki: ");
            int number = Convert.ToInt32(Console.ReadLine());
            foreach (var book in Library.booksList.Where(x => x.NumberID == number))
            {
                book.Available = true;
                book.Borrower = "";
                book.Return_date = DateTime.Now;
            }
        }
    }
}
