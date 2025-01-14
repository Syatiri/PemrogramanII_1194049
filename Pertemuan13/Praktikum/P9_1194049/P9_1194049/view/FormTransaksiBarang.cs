using P9_1194049.controller;
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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using P9_1194049.lib;
using System.IO;

namespace P9_1194049.view
{
    public partial class FormTransaksiBarang : Form
    {
        Koneksi koneksi = new Koneksi();
        M_transaksi_barang m_transaksi_barang = new M_transaksi_barang();
        string id_transaksi_barang;

        decimal hargaBarang = 0;

        public FormTransaksiBarang()
        {
            InitializeComponent();
        }

        private void FormTransaksiBarang_Load(object sender, EventArgs e)
        {

            Tampil();
            LoadComboBoxBarang();
        }

        public void Tampil()
        {
            DataTransaksiBarang.DataSource = koneksi.ShowData("SELECT id_transaksi, t_transaksi.id_barang, nama_barang, harga, qty, total " + "FROM t_transaksi " + "JOIN t_barang ON t_transaksi.id_barang = t_barang.id_barang");

            DataTransaksiBarang.Columns[0].HeaderText = "ID";
            DataTransaksiBarang.Columns[1].HeaderText = "ID Barang";
            DataTransaksiBarang.Columns[2].HeaderText = "Nama Barang";
            DataTransaksiBarang.Columns[3].HeaderText = "Harga";
            DataTransaksiBarang.Columns[4].HeaderText = "Quantity";
            DataTransaksiBarang.Columns[5].HeaderText = "Total Harga";
        }

        private void DataTransaksiBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idTransaksi = DataTransaksiBarang.Rows[e.RowIndex].Cells[0].Value.ToString(); 
                string idBarang = DataTransaksiBarang.Rows[e.RowIndex].Cells[1].Value.ToString();  
                string namaBarang = DataTransaksiBarang.Rows[e.RowIndex].Cells[2].Value.ToString(); 
                string harga = DataTransaksiBarang.Rows[e.RowIndex].Cells[3].Value.ToString();
                string qty = DataTransaksiBarang.Rows[e.RowIndex].Cells[4].Value.ToString(); 
                string total = DataTransaksiBarang.Rows[e.RowIndex].Cells[5].Value.ToString(); 

                comboBoxIdBarang.Text = idBarang;
                textBoxNamaBarang.Text = namaBarang;
                textBoxHargaBarang.Text = harga;
                textBoxQuantity.Text = qty;
                textBoxTotal.Text = total;

                id_transaksi_barang = idTransaksi;
            }
        }

        private void textBoxCariData_TextChanged(object sender, EventArgs e)
        {
            string query;

            if (string.IsNullOrEmpty(textBoxCariData.Text))
            {
                query = "SELECT id_transaksi, t_transaksi.id_barang, nama_barang, harga, qty, total " +
                        "FROM t_transaksi " +
                        "JOIN t_barang ON t_transaksi.id_barang = t_barang.id_barang";
            }
            else
            {
                query = "SELECT id_transaksi, t_transaksi.id_barang, nama_barang, harga, qty, total " +
                        "FROM t_transaksi " +
                        "JOIN t_barang ON t_transaksi.id_barang = t_barang.id_barang " +
                        "WHERE t_transaksi.id_barang LIKE '%' + '" + textBoxCariData.Text + "' + '%' " +
                        "OR t_barang.nama_barang LIKE '%' + '" + textBoxCariData.Text + "' + '%'";
            }

            DataTransaksiBarang.DataSource = koneksi.ShowData(query);
        }

        private void LoadComboBoxBarang()
        {
            var data = koneksi.ShowData("SELECT id_barang, nama_barang FROM t_barang");
            comboBoxIdBarang.DataSource = data;
            comboBoxIdBarang.DisplayMember = "id_barang";
            comboBoxIdBarang.ValueMember = "id_barang";
        }

        

        private void comboBoxIdBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxIdBarang.SelectedValue != null)
            {
                string selectedId = comboBoxIdBarang.SelectedValue.ToString(); 

                try
                {
                    koneksi.OpenConnection();

                    MySqlDataReader reader = koneksi.reader("SELECT nama_barang, harga FROM t_barang WHERE id_barang = '" + selectedId + "'");

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            textBoxNamaBarang.Text = reader["nama_barang"].ToString();  
                            hargaBarang = Convert.ToDecimal(reader["harga"]);  
                            textBoxHargaBarang.Text = hargaBarang.ToString();  
                        }
                    }
                    else
                    {
                        textBoxNamaBarang.Clear();
                        textBoxHargaBarang.Clear();
                    }

                    reader.Close();
                    koneksi.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                textBoxNamaBarang.Clear();
                textBoxHargaBarang.Clear();
            }
        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxQuantity.Text, out decimal quantity) && quantity > 0)
            {
                decimal total = hargaBarang * quantity;

                textBoxTotal.Text = total.ToString();
            }
            else
            {
                textBoxTotal.Clear();
            }
        }

        private void ResetForm()
        {
            comboBoxIdBarang.SelectedIndex = -1; 
            textBoxNamaBarang.Text = ""; 
            textBoxHargaBarang.Text = "";
            textBoxQuantity.Text = ""; 
            textBoxTotal.Text = ""; 
            id_transaksi_barang = null;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetForm();
            Tampil();
        }


        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxIdBarang.Text) ||
             string.IsNullOrWhiteSpace(textBoxNamaBarang.Text) ||
             string.IsNullOrWhiteSpace(textBoxHargaBarang.Text) ||
             string.IsNullOrWhiteSpace(textBoxQuantity.Text))
            {
                MessageBox.Show("Semua data harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!decimal.TryParse(textBoxHargaBarang.Text, out decimal hargaSatuan) || hargaSatuan <= 0)
                {
                    MessageBox.Show("Harga harus berupa angka positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Quantity harus berupa angka positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal total = hargaSatuan * quantity;

                M_transaksi_barang transaksi = new M_transaksi_barang
                {
                    Id_barang = comboBoxIdBarang.SelectedValue?.ToString(),
                    Qty = quantity.ToString(),
                    Total = total.ToString()
                };

                TransaksiBarang trxBarang = new TransaksiBarang();
                if (trxBarang.Insert(transaksi))
                {
                    MessageBox.Show("Data transaksi berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetForm();
                    Tampil();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data transaksi.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(id_transaksi_barang))
            {
                MessageBox.Show("Pilih data transaksi yang ingin diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxIdBarang.Text) ||
                string.IsNullOrWhiteSpace(textBoxNamaBarang.Text) ||
                string.IsNullOrWhiteSpace(textBoxHargaBarang.Text) ||
                string.IsNullOrWhiteSpace(textBoxQuantity.Text))
            {
                MessageBox.Show("Semua data harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!decimal.TryParse(textBoxHargaBarang.Text, out decimal hargaSatuan) || hargaSatuan <= 0)
                {
                    MessageBox.Show("Harga harus berupa angka positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Quantity harus berupa angka positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal total = hargaSatuan * quantity;

                M_transaksi_barang transaksi = new M_transaksi_barang
                {
                    Id_barang = comboBoxIdBarang.SelectedValue.ToString(), 
                    Qty = quantity.ToString(),
                    Total = total.ToString()
                };

                TransaksiBarang trxBarang = new TransaksiBarang();
                if (trxBarang.Update(transaksi, id_transaksi_barang)) 
                {
                    MessageBox.Show("Data transaksi berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetForm();
                    Tampil(); 

                    DataTransaksiBarang.Refresh(); 
                }
                else
                {
                    MessageBox.Show("Gagal mengubah data transaksi.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id_transaksi_barang))
            {
                DialogResult pesan = MessageBox.Show("Apakah yakin akan menghapus data ini?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (pesan == DialogResult.Yes)
                {
                    try
                    {
                        TransaksiBarang trxBarang = new TransaksiBarang();
                        bool berhasilHapus = trxBarang.Delete(id_transaksi_barang); 

                        if (berhasilHapus)
                        {
                            foreach (DataGridViewRow row in DataTransaksiBarang.SelectedRows)
                            {
                                DataTransaksiBarang.Rows.RemoveAt(row.Index); 
                            }

                            ResetForm();
                            Tampil();
                        }
                        else
                        {
                            MessageBox.Show("Gagal menghapus data transaksi.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data transaksi yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void DataTransaksiBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DataTransaksiBarang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DataTransaksiBarang.Columns[e.ColumnIndex].HeaderText == "Harga" ||
        DataTransaksiBarang.Columns[e.ColumnIndex].HeaderText == "Total Harga")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = string.Format("Rp {0:N0}", value);
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Documents (*.xlxs)|*.xlxs";
            save.FileName = "Report Transaksi Barang.xlxs";

            if (save.ShowDialog() == DialogResult.OK)
            {
                string directory = Path.GetDirectoryName(save.FileName);
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(save.FileName);
                string extension = Path.GetExtension(save.FileName);
                int count = 1;
                string filePath = save.FileName;
                while (File.Exists(filePath))
                {
                    filePath = Path.Combine(directory, $"{fileNameWithoutExt} ({count}){extension}");
                    count++;
                }

                Excel excel_lib = new Excel();

                excel_lib.ExportToExcel(DataTransaksiBarang, filePath);

                MessageBox.Show("Data berhasil diekspor ke file Excel.",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
