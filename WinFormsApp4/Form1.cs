using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox3.Text != "")
            {
                if (authLogin(textBox1.Text, textBox3.Text))
                MessageBox.Show("Login berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 form2 = new Form2();
                this.Hide();
                form2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username dan Password tidak boleh kosong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Username atau Password salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool authLogin(string username, string password)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=daffa21122005;Database=coba;port = 5432");
            conn.Open();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand();
            npgsqlCommand.Connection = conn;
            npgsqlCommand.CommandText = $"SELECT * from Akun where username = '{username}' AND password = '{password}' ";
            NpgsqlDataReader data = npgsqlCommand.ExecuteReader();
            bool result = data.Read();
            conn.Close();
            return result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.PasswordChar == '*')
            {
                textBox1.PasswordChar = '\0';
                button2.Text = "Hide";
            }

            else
            {
                textBox1.PasswordChar = '*';
                button2.Text = "Show";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
