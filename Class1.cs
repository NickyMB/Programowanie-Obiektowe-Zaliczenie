using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{   // Klasa z książkami
    internal class Book
    {
        public int NumberID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN_number { get; set; }
        public string Publisher { get; set; }
        public string Publication_year { get; set; }
        public string Category { get; set; }
        public bool Available { get; set; }
        public string Borrower { get; set; }
        public DateTime Borrow_date { get; set; }
        public DateTime Return_date { get; set; }

        public Book(int numberID, string title, string author, string isbn_number, string publisher, string publication_year, string category, bool available)
        {
            NumberID = numberID;
            Title = title;
            Author = author;
            ISBN_number = isbn_number;
            Publisher = publisher;
            Publication_year = publication_year;
            Category = category;
            Available = available;
        }
        // Klasa używana podczas wypożyczania książek
        public Book(int numberID, string title, string author, string isbn_number, string publisher, string publication_year, string category, bool available, string borrower, DateTime borrow_date)
        {
            NumberID = numberID;
            Title = title;
            Author = author;
            ISBN_number = isbn_number;
            Publisher = publisher;
            Publication_year = publication_year;
            Category = category;
            Available = available;
            Borrower = borrower;
            Borrow_date = borrow_date;
        }
        // Klasa używana podczas oddawania książek
        public Book(int numberID, string title, string author, string isbn_number, string publisher, string publication_year, string category, bool available, string borrower, DateTime borrow_date, DateTime return_date)
        {
            NumberID = numberID;
            Title = title;
            Author = author;
            ISBN_number = isbn_number;
            Publisher = publisher;
            Publication_year = publication_year;
            Category = category;
            Available = available;
            Borrower = borrower;
            Borrow_date = borrow_date;
            Return_date = return_date;
        }
    }
    // class containing objects of information about the borrower
    internal class Borrower
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Borrower_number { get; set; }
        public DateTime Borrow_date { get; set; }
        public DateTime Return_date { get; set; }

        public Borrower(string name, string email, int borrower_number, DateTime borrow_date, DateTime return_date)
        {
            Name = name;
            Email = email;
            Borrower_number = borrower_number;
            Borrow_date = borrow_date;
            Return_date = return_date;
        }

    }
}