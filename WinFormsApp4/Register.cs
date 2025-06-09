using Npgsql;
using System.Text;
using System.Security.Cryptography;

namespace WinFormsApp4
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=Gun180106;Database=anjir";

            string email = textBox1.Text.Trim();
            string username = textBox2.Text.Trim();
            string password = textBox3.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Semua field harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string cekQuery = "SELECT COUNT(*) FROM users WHERE username = @user";
                    using (var cekCmd = new NpgsqlCommand(cekQuery, conn))
                    {
                        cekCmd.Parameters.AddWithValue("user", username);
                        long count = (long)cekCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Username sudah digunakan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = "INSERT INTO users (email, username, password) VALUES (@email, @user, @pass)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("user", username);
                        cmd.Parameters.AddWithValue("pass", password);

                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("Registrasi berhasil!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form1 form1 = new Form1();
                            this.Hide();
                            form1.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Registrasi gagal!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi error: " + ex.Message);
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
            //this.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
