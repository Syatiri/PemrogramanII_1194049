using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_2_1194049
{
    public class Magazine : LibraryItem
    {
        private string issue;

        public string Issue
        {
            get { return issue; }
            set { issue = value; }
        }

        public Magazine(string title, string author, int year, string issue)
            : base(title, author, year)
        {
            this.issue = issue;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Magazine: {title}");
            Console.WriteLine($"Publisher: {author}");
            Console.WriteLine($"Year: {year}");
            Console.WriteLine($"Issue: {issue}");
        }

        public override string GetItemType()
        {
            return "Magazine";
        }
    }
}