﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibiotekav2
{   // class containing objects for books
    internal class Book
    {
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

        public Book(string title, string author, string isbn_number, string publisher, string publication_year, string category, bool available)
        {
            Title = title;
            Author = author;
            ISBN_number = isbn_number;
            Publisher = publisher;
            Publication_year = publication_year;
            Category = category;
            Available = available;
        }
        public Book(string title, string author, string isbn_number, string publisher, string publication_year, string category, bool available, string borrower, DateTime borrow_date, DateTime return_date)
        {
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
        // generate unique borrower number
        public static int GenerateBorrowerNumber()
        {
            int i = 0;
            int ran;
            List<int> digits = new List<int>();
            Random random = new Random();
            do
            {
                ran = random.Next(1, 9999);
                if (!digits.Contains(ran))
                {
                    digits.Add(ran);
                    i = 1;
                }
            } while (i != 1);
            return ran;
        }
    }
}