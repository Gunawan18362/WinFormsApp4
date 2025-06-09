using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fitur_gejalaumum
{
    public partial class Form3 : Form
    {
        public Form3(Lanjutan lanjutan)
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int id))
            {
                MessageBox.Show("ID tidak valid");
                return;
            }

            Lanjutan pasien21 = new Lanjutan(0, "", 0, "", "", "", "");
            pasien21.Id = Convert.ToInt32(textBox1.Text);
            pasien21.GejalaLanjutan = comboBox1.Text;
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Database=coba coba;port=5432;Password=1234");
            conn.Open();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand();
            npgsqlCommand.Connection = conn;
            npgsqlCommand.CommandText = $"SELECT COUNT(*) FROM akun WHERE no_antrian = {pasien21.Id}";
            npgsqlCommand.Parameters.AddWithValue("no_antrian", pasien21.Id);
            int count = Convert.ToInt32(npgsqlCommand.ExecuteScalar());

            if (count == 0)
            {
                MessageBox.Show("ID tidak ditemukan.");
                conn.Close();
                return;
            }

            npgsqlCommand.CommandText = $" UPDATE akun SET gejala_lanjutan = '{pasien21.GejalaLanjutan}' WHERE no_antrian = {pasien21.Id}";
            npgsqlCommand.Parameters.AddWithValue("@gejala_lanjutan", pasien21.GejalaLanjutan);
            int result = npgsqlCommand.ExecuteNonQuery();

            if (result > 0)
                MessageBox.Show("Data lanjutan berhasil diperbarui.");
            else
                MessageBox.Show("Tidak ada data yang diperbarui.");

            var selectCmd = new NpgsqlCommand("SELECT * FROM akun WHERE no_antrian = @id", conn);
            selectCmd.Parameters.AddWithValue("id", pasien21.Id);
            using (var reader = selectCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    pasien21.Umur = Convert.ToInt32(reader["umur"]);
                    pasien21.Gejala = reader["gejala"].ToString();
                    pasien21.Kategori = reader["kategori"].ToString();
                    pasien21.Alergi = reader["alergi"].ToString();
                    pasien21.GejalaLanjutan = reader["gejala_lanjutan"].ToString();
                }
            }

            // Cari Obat berdasarkan kriteria
            string query = @"
                    SELECT obat_kimia FROM obat
                    WHERE @umur BETWEEN umur_min AND umur_max
                      AND gejala = @gejala
                      AND kategori = @kategori
                      AND alergi = @alergi
                      AND (gejala_lanjutan IS NULL OR gejala_lanjutan = @gejala_lanjutan)
                    LIMIT 1";

            var obatCmd = new NpgsqlCommand(query, conn);
            obatCmd.Parameters.AddWithValue("umur", pasien21.Umur);
            obatCmd.Parameters.AddWithValue("gejala", pasien21.Gejala);
            obatCmd.Parameters.AddWithValue("kategori", pasien21.Kategori);
            obatCmd.Parameters.AddWithValue("alergi", pasien21.Alergi);
            obatCmd.Parameters.AddWithValue("gejala_lanjutan", pasien21.GejalaLanjutan);

            string obatKimia = "Tidak ditemukan obat yang cocok.";
            var well = obatCmd.ExecuteScalar();
            if (well != null)
                obatKimia = well.ToString();
         
            
            Obat11 obatObj = new Obat11(obatKimia, "", "", pasien21.GejalaLanjutan);
            farm0111 hasilForm = new farm0111(obatObj.ObatKimia, obatObj.KategoriLanjutan);
            this.Hide();
            hasilForm.ShowDialog();
            this.Close();
            




        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gejala formm = new gejala();
            this.Hide();
            formm.ShowDialog();
            this.Close();
        }
    }
}
