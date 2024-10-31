using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_2_1194049
{
    public class Book : LibraryItem
    {
        private int pages;

        public int Pages
        {
            get { return pages; }
            set { pages = value; }
        }

        public Book(string title, string author, int year, int pages)
            : base(title, author, year)
        {
            this.pages = pages;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Book: {title}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Year: {year}");
            Console.WriteLine($"Pages: {pages}");
        }

        public override string GetItemType()
        {
            return "Book";
        }
    }
}