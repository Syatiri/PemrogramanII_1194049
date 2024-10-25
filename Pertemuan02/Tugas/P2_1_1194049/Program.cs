using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_1_1194049
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Angka pertama: ");
            double angkaPertama = Convert.ToDouble(Console.ReadLine());

            Console.Write("Angka kedua: ");
            double angkaKedua = Convert.ToDouble(Console.ReadLine());

            double penjumlahan = angkaPertama + angkaKedua;
            double pengurangan = angkaPertama - angkaKedua;
            double perkalian = angkaPertama * angkaKedua;
            double pembagian = angkaPertama / angkaKedua;
            
            Console.WriteLine("\nHasil Operasi Aritmatika:");
            Console.WriteLine($"Penjumlahan: {angkaPertama} + {angkaKedua} = {penjumlahan}");
            Console.WriteLine($"Pengurangan: {angkaPertama} - {angkaKedua} = {pengurangan}");
            Console.WriteLine($"Perkalian: {angkaPertama} * {angkaKedua} = {perkalian}");
            Console.WriteLine($"Pembagian: {angkaPertama} / {angkaKedua} = {pembagian}");

            Console.ReadKey();
        }
    }
}