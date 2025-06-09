using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fitur_gejalaumum;
using Npgsql;

namespace fitur_gejalaumum
{
    public partial class farm011 : Form
    {
        private Konsultasi pasien;

        public farm011(Konsultasi konsultasi)
        {
            InitializeComponent();
            pasien = konsultasi;
        }

        private void farm011_Load(object sender, EventArgs e)
        { 
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Database=coba coba;port=5432;Password=1234");
            conn.Open();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand();
            npgsqlCommand.Connection = conn;
            npgsqlCommand.CommandText = $" SELECT * FROM obat1 WHERE {pasien.Umur} BETWEEN umur_min AND umur_max AND gejala = '{pasien.Gejala}' AND kategori = '{pasien.Kategori}' AND alergi = '{pasien.Alergi}'";
            NpgsqlDataReader data = npgsqlCommand.ExecuteReader();
            Obat result = null;
            if (data.Read())
            {
                result = new Obat(
                data["obat_kimia"].ToString(),
                data["obat_herbal"].ToString(),
                data["lifestyle"].ToString()
                );
            }

            conn.Close();

            if (result != null)
            {
                label1.Text = "Obat Kimia: " + result.ObatKimia;
                label2.Text = "Obat Herbal: " + result.ObatHerbal;
                label3.Text = "Saran Lifestyle: " + result.Lifestyle;
            }
            else
            {
                label1.Text = "Obat Kimia: Data tidak ditemukan";
                label2.Text = "Obat Herbal: Data tidak ditemukan";
                label3.Text = "Saran Lifestyle: Data tidak ditemukan";
            }

            DataTable DataTable = new DataTable();
            NpgsqlConnection conn2 = new NpgsqlConnection("Host=localhost;Username=postgres;Database=coba coba;port=5432;Password=1234");
            conn2.Open();
            NpgsqlCommand npgsqlCommand1 = new NpgsqlCommand();
            npgsqlCommand1.Connection = conn2;
            npgsqlCommand1.CommandText = $"SELECT no_antrian, nama, umur, gejala, kategori, alergi FROM akun ORDER BY no_antrian DESC LIMIT 1";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(npgsqlCommand1);
            adapter.Fill(DataTable);
            conn2.Close();
            dataGridView1.DataSource = DataTable;
            dataGridView1.Columns["no_antrian"].HeaderText = "No Antrian";
            dataGridView1.Columns["nama"].HeaderText = "Nama";
            dataGridView1.Columns["umur"].HeaderText = "Umur";
            dataGridView1.Columns["gejala"].HeaderText = "Gejala";
            dataGridView1.Columns["kategori"].HeaderText = "Kategori";
            dataGridView1.Columns["alergi"].HeaderText = "Alergi";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Lanjutan lanjutanKosong = new Lanjutan(0, "Tidak diketahui", 0, "", "", "", "");
            Form3 form = new Form3(lanjutanKosong);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}