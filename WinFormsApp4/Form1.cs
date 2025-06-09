using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
    int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
    int nWidthEllipse, int nHeightEllipse);

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_LoadSetup(object sender, EventArgs e)
        {
            SetupRoundedForm();
        }

        private void SetupRoundedForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 25, 25));
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox3.Text.Trim();

            if (textBox1.Text != "" && textBox3.Text != "")
            {

                using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=1234;Database=well"))
                {
                    conn.Open();
                    string query = "SELECT user_id, username FROM users WHERE username = @username";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", textBox1.Text);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User.Id = reader.GetInt32(0);
                                User.Username = reader.GetString(1);  
                            }
                        }
                    }
                }

                if (authLogin(textBox1.Text, textBox3.Text))
                    MessageBox.Show("Login berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 form2 = new Form2(textBox3.Text);
                this.Hide();
                form2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username dan Password tidak boleh kosong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool authLogin(string username, string password)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=1234;Database=well;port = 5432");
            conn.Open();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand();
            npgsqlCommand.Connection = conn;
            npgsqlCommand.CommandText = $"SELECT * from users where username = '{username}' AND password = '{password}' ";
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
                button2.Text = "👁️";
            }

            else
            {
                textBox1.PasswordChar = '*';
                button2.Text = "🔒";
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }
    }
}
