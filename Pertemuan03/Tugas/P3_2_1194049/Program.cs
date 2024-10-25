using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_2_1194049
{
    class Program
    {
        static void Main(string[] args)
        {

            bool ulang = true;
            while (ulang)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Persegi Panjang ===");
                Console.WriteLine("1. Hitung Luas");
                Console.WriteLine("2. Hitung Keliling");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih menu: ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        HitungLuas();
                        break;

                    case "2":
                        HitungKeliling();
                        break;

                    case "3":
                        ulang = false;
                        Console.WriteLine("Program Selesai");
                        Console.WriteLine("Program Selesai Terima kasih!");
                        break;

                    default:
                        Console.WriteLine("Menu tidak tersedia. Silahkan pilih menu yang valid.");
                        UlangAtauKeluar();
                        break;
                }
            }
        }

        static void HitungLuas()
        {
            Console.Write("Masukkan panjang: ");
            double panjang = Convert.ToDouble(Console.ReadLine());
            Console.Write("Masukkan lebar: ");
            double lebar = Convert.ToDouble(Console.ReadLine());

            double luas = panjang * lebar;
            Console.WriteLine($"Luas persegi panjang: {luas}");

            UlangAtauKeluar();
        }

        static void HitungKeliling()
        {
            Console.Write("Masukkan panjang: ");
            double panjang = Convert.ToDouble(Console.ReadLine());
            Console.Write("Masukkan lebar: ");
            double lebar = Convert.ToDouble(Console.ReadLine());

            double keliling = 2 * (panjang + lebar);
            Console.WriteLine($"Keliling persegi panjang: {keliling}");

            UlangAtauKeluar();
        }

        static void UlangAtauKeluar()
        {
            Console.WriteLine("Apakah ingin mengulang? (Y/T)");
            string ulang = Console.ReadLine().ToUpper();

            if (ulang == "Y")
            {
                Console.WriteLine("Kembali ke menu...");
            }
            else if (ulang == "T")
            {
                Console.WriteLine("Program Selesai");
                Console.WriteLine("Terima Kasih!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Input tidak valid. Mengulang program...");
            }
        }
    }
}
