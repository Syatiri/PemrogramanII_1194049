using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_2_1194049
{
    public abstract class LibraryItem
    {
        protected string title;
        protected string author;
        protected int year;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        protected LibraryItem(string title, string author, int year)
        {
            this.title = title;
            this.author = author;
            this.year = year;
        }

        public abstract void DisplayInfo();

        public new virtual string GetItemType()
        {
            return "Library Item";
        }
    }
}