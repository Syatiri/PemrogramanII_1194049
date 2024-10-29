using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_1_1194049
{
    class ProductTest_1194049
    {
        static void Main(string[] args)
        {
            Book_1194049 product1 = new Book_1194049("Book", "C# Object Oriented Solution", "300");
            DVD_1194049 product2 = new DVD_1194049("Ethernal Sunshine Of The Spotless Mind", "145");

            product1.DisplayInfo();
            product2.DisplayInfo();
        }
    }
}
