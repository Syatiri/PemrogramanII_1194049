using System.Reflection.Metadata;
using System;
using System.Windows.Forms;

namespace P5_4_1194049
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeGenderComboBox();
        }

        private void InitializeGenderComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("--Pilih Jenis Kelamin--");
            comboBox1.Items.Add("Pria");
            comboBox1.Items.Add("Wanita");
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Nama harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Jenis Kelamin harus dipilih!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked))
            {
                MessageBox.Show("Harus memilih salah satu dari pilihan jadwal", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked ||
                  checkBox5.Checked || checkBox6.Checked || checkBox7.Checked || checkBox8.Checked))
            {
                MessageBox.Show("Harus memilih salah satu dari pilihan kelas", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string jadwal = "";
            if (radioButton1.Checked) jadwal = "Senin s/d Rabu, 14.00-16.00";
            if (radioButton2.Checked) jadwal = "Selasa s/d Kamis, 14.00-16.00";
            if (radioButton3.Checked) jadwal = "Sabtu s/d Minggu, 09.00-11.00";
            if (radioButton4.Checked) jadwal = "Minggu, 13.00-20.00";

            string kelas = "";
            if (checkBox1.Checked) kelas += "Sepak Bola, ";
            if (checkBox2.Checked) kelas += "Renang, ";
            if (checkBox3.Checked) kelas += "Tenis, ";
            if (checkBox4.Checked) kelas += "Yoga, ";
            if (checkBox5.Checked) kelas += "Basket, ";
            if (checkBox6.Checked) kelas += "Bulu Tangkis, ";
            if (checkBox7.Checked) kelas += "Voli, ";
            if (checkBox8.Checked) kelas += "Panahan, ";

            string pesan = "Nama: " + textBox1.Text + "\n" +
                           "Jenis Kelamin: " + comboBox1.SelectedItem.ToString() + "\n" +
                           "Tanggal Lahir: " + dateTimePicker1.Value.ToString("dd MMMM yyyy") + "\n" +
                           "Pilihan Kelas: " + kelas + "\n" +
                           "Pilihan Jadwal: " + jadwal;

            MessageBox.Show(pesan, "Informasi Pendaftaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
