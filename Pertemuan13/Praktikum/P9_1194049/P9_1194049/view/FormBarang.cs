using P9_1194049.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using P9_1194049.controller;

namespace P9_1194049.view
{
    public partial class FormBarang : Form
    {
        Koneksi koneksi = new Koneksi();
        M_barang m_Barang = new M_barang();
        string id_barang; 

        public void Tampil()
        {
            DataBarang.DataSource = koneksi.ShowData("SELECT id_barang, nama_barang, harga FROM t_barang");

            DataBarang.Columns[0].HeaderText = "ID";
            DataBarang.Columns[1].HeaderText = "Nama Barang";
            DataBarang.Columns[2].HeaderText = "Harga";

            
        }

        public FormBarang()
        {
            InitializeComponent();
        }

        private void FormBarang_Load(object sender, EventArgs e)
        {
            Tampil();
            
        }

        

        private void DataBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_barang = DataBarang.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxNamaBarang.Text = DataBarang.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxHarga.Text = DataBarang.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void textBoxCariData_TextChanged(object sender, EventArgs e)
        {
            DataBarang.DataSource = koneksi.ShowData("SELECT id_barang, nama_barang, harga " + "FROM t_barang " +
            "WHERE id_barang LIKE '%" + textBoxCariData.Text + "%' " +
            "OR nama_barang LIKE '%" + textBoxCariData.Text + "%' " +
            "OR harga LIKE '%" + textBoxCariData.Text + "%'");
        }

        public void ResetForm()
        {
            textBoxNamaBarang.Text = "";
            textBoxHarga.Text = "";
            textBoxCariData.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetForm();
            Tampil();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxNamaBarang.Text == "" || textBoxHarga.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                M_barang m_barang = new M_barang
                {
                    Nama_barang = textBoxNamaBarang.Text,
                    Harga = textBoxHarga.Text
                };

                Barang barang = new Barang();

                if (barang.Insert(m_barang))
                {
                    ResetForm();
                    Tampil();
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNamaBarang.Text) || string.IsNullOrWhiteSpace(textBoxHarga.Text))
            {
                MessageBox.Show("Nama Barang dan Harga tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    M_barang m_barang = new M_barang
                    {
                        Nama_barang = textBoxNamaBarang.Text,
                        Harga = textBoxHarga.Text
                    };

                    Barang barang = new Barang();

                    if (barang.Update(m_barang, id_barang))
                    {
                        ResetForm();
                        Tampil();
                        MessageBox.Show("Data berhasil diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data gagal diubah atau tidak ditemukan", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Apakah yakin akan menghapus data ini?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pesan == DialogResult.Yes)
            {
                Barang barang = new Barang();
                string idBarangValue = id_barang; 

                barang.Delete(idBarangValue);

                ResetForm();
                Tampil();
            }
        }

        private void DataBarang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DataBarang.Columns[e.ColumnIndex].HeaderText == "Harga" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal harga))
                {
                    e.Value = $"Rp {harga:N0}";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
