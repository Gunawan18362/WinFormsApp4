using fitur_gejalaumum;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace fitur_gejalaumum
{
    public partial class gejala : Form
    {
        public gejala()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comobox combo = new comobox();
            comboBox1.Items.AddRange(comobox.DataCombo.GejalaList.ToArray());
            comboBox2.Items.AddRange(comobox.DataCombo.AlergiList.ToArray());
            comboBox3.Items.AddRange(comobox.DataCombo.KategoriList.ToArray());

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                string nama = textBox2.Text;
                if (string.IsNullOrWhiteSpace(nama))
                {
                    MessageBox.Show("Nama tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(textBox1.Text, out int umur))
                {
                    MessageBox.Show("Umur tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Pass pasien = new Pass(nama, umur);
                string kategoriUmur = pasien.TentukanKategoriUmur();

                if (kategoriUmur == null)
                {
                    MessageBox.Show("Umur terlalu kecil atau tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool Validation = Validasi(nama, umur, comboBox1.Text, comboBox2.Text, comboBox3.Text, kategoriUmur);
                Konsultasi konsultasi = new Konsultasi(nama, umur, comboBox1.Text, comboBox3.Text, comboBox2.Text);
                if (Validation)
                {
                    MessageBox.Show($"Input gejala berhasil.", "Gejala", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    farm011 farm = new farm011(konsultasi);
                    this.Hide();
                    farm.ShowDialog();
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Masukan tidak boleh kosong atau terjadi kesalahan penyimpanan.", "Gejala", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private bool Validasi (string nama, int umur, string gejala, string alergi, string kategori, string kategoriUmur)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Database=coba coba;port = 5432;Password = 1234");
            conn.Open();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand();
            npgsqlCommand.Connection = conn;
            npgsqlCommand.CommandText = $"INSERT INTO akun(nama, umur, gejala, alergi, kategori, kategori_umur) VALUES ('{nama}','{umur}', '{gejala}', '{alergi}', '{kategori}','{kategoriUmur}')";
            try
            {
                npgsqlCommand.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
