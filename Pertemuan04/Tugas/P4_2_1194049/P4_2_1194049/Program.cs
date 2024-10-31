using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_2_1194049
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Library Management System\n");

            Book book = new Book("Buku Manajemen Sistem Library", "M. Hadi Syatiri", 2024, 223);

            Magazine magazine = new Magazine("ULBI", "Buku Pedia", 2024, "Edisi Terlaris");

            Console.WriteLine("=== Book Information ===");
            book.DisplayInfo();
            Console.WriteLine($"Type: {book.GetItemType()}\n");

            Console.WriteLine("=== Magazine Information ===");
            magazine.DisplayInfo();
            Console.WriteLine($"Type: {magazine.GetItemType()}");

            Console.ReadKey();
        }
    }
}