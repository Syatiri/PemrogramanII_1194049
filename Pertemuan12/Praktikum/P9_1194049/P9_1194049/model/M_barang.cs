using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace P9_1194049.model
{
    internal class M_barang
    {
        string nama_barang, harga;
        public M_barang()
        {
        }
        public M_barang(string nama_barang, string harga)
        {
            this.Nama_barang = nama_barang;
            this.Harga = harga;
        }
        public string Nama_barang
        {
            get => nama_barang; set => nama_barang =
        value;
        }
        public string Harga { get => harga; set => harga = value; }
    }
}
