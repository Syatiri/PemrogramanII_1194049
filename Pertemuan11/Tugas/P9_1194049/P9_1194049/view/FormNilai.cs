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
    public partial class FormNilai : Form
    {
        Koneksi koneksi = new Koneksi();
        M_nilai m_Nilai = new M_nilai();
        string id_nilai;

        public void Tampil()
        {
            DataNilai.DataSource = koneksi.ShowData("SELECT id_nilai, matkul,\r\nkategori, t_nilai.npm, nama, nilai FROM t_nilai JOIN t_mahasiswa ON\r\nt_mahasiswa.npm = t_nilai.npm");

            DataNilai.Columns[0].HeaderText = "ID";
            DataNilai.Columns[1].HeaderText = "Matkul";
            DataNilai.Columns[2].HeaderText = "Kategori";
            DataNilai.Columns[3].HeaderText = "NPM";
            DataNilai.Columns[4].HeaderText = "Nama";
            DataNilai.Columns[5].HeaderText = "Nilai";
        }
        public FormNilai()
        {
            InitializeComponent();
        }

        private void FormNilai_Load(object sender, EventArgs e)
        {
            Tampil();
            GetDataMhs();
        }

        public void GetDataMhs()
        {
            koneksi.OpenConnection();

            MySqlDataReader reader = koneksi.reader("SELECT * FROM t_mahasiswa");
            while (reader.Read())
            {
                int npm = reader.GetInt32("npm");
                checkBoxNpm.Items.Add(npm);
            }
            reader.Close();
            koneksi.CloseConnection();
        }

        private void DataNilai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_nilai = DataNilai.Rows[e.RowIndex].Cells[0].Value.ToString();
            checkBoxMatkul.Text = DataNilai.Rows[e.RowIndex].Cells[1].Value.ToString();
            checkBoxKategori.Text = DataNilai.Rows[e.RowIndex].Cells[2].Value.ToString();
            checkBoxNpm.Text = DataNilai.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxNilai.Text = DataNilai.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void textBoxCariData_TextChanged(object sender, EventArgs e)
        {
            DataNilai.DataSource = koneksi.ShowData("SELECT id_nilai, matkul, kategori,t_nilai.npm, nama, nilai " +
            "FROM t_nilai JOIN t_mahasiswa ON t_mahasiswa.npm = t_nilai.npm " +
            "WHERE t_nilai.npm LIKE '%' '" + textBoxCariData.Text + "' '%' " +
            "OR nama LIKE '%' '" + textBoxCariData.Text + "' '%'" +
            "OR matkul LIKE '%' '" + textBoxCariData.Text + "' '%'");
        }

        public void GetNamaMhs()
        {
            koneksi.OpenConnection();
            MySqlDataReader reader = koneksi.reader("SELECT nama FROM t_mahasiswa WHERE npm = '" + checkBoxNpm.Text + "'");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    textBoxNama.Text = reader.GetString(0);
                }
            }
            reader.Close();
            koneksi.CloseConnection();
        }

        private void checkBoxNpm_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNamaMhs();
        }

        public void ResetForm()
        {
            checkBoxMatkul.SelectedIndex = -1;
            checkBoxKategori.SelectedIndex = -1;
            checkBoxNpm.SelectedIndex = -1;
            textBoxNilai.Text = "";
            textBoxNama.Text = "";
            textBoxCariData.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetForm();
            Tampil();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (checkBoxMatkul.SelectedIndex == -1 || checkBoxKategori.SelectedIndex == -1 || checkBoxNpm.SelectedIndex == -1 || textBoxNilai.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Nilai nilai = new Nilai();
                m_Nilai.Matkul = checkBoxMatkul.Text;
                m_Nilai.Kategori = checkBoxKategori.Text;
                m_Nilai.Npm = checkBoxNpm.Text;
                m_Nilai.Nilai = textBoxNilai.Text;

                nilai.Insert(m_Nilai);

                ResetForm();
                Tampil();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (checkBoxMatkul.SelectedIndex == -1 || checkBoxKategori.SelectedIndex == -1 || checkBoxNpm.SelectedIndex == -1 || textBoxNilai.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Nilai nilai = new Nilai();
                m_Nilai.Matkul = checkBoxMatkul.Text;
                m_Nilai.Kategori = checkBoxKategori.Text;
                m_Nilai.Npm = checkBoxNpm.Text;
                m_Nilai.Nilai = textBoxNilai.Text;

                nilai.Update(m_Nilai, id_nilai);

                ResetForm();
                Tampil();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Apakah yakin akan menghapus data ini?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pesan == DialogResult.Yes)
            {
                Nilai nilai = new Nilai();
                nilai.Delete(id_nilai);

                ResetForm();
                Tampil();
            }
        }
    }
}
