using System;
using System.Collections.Generic;
using System.Text;

namespace P02._Books_Before
{
    public class Library
    {
        public Dictionary<Book, int> Books { get; set; }

        public int GetPage(Book book)
        {

            return Books[book];
        
        }

        public int SetPage(Book book, int newPage)
        {

            return Books[book] = newPage;

        }


    }
}
