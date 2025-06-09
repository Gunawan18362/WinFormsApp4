using Npgsql;
namespace Ibu_hamil
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        public Form11(string nama)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                bool berhasil = SimpanDataIbuHamil(textBox1.Text, textBox2.Text, dateTimePicker1.Value);
                if (berhasil)
                {
                    MessageBox.Show("Simpan Berhasil", "Simpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form11 form1 = new Form11(textBox1.Text);
                    this.Hide();
                    form1.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Harap Memasukkan nama/usia kehamilan/trimester dengan benar", "Simpan Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }



        private bool SimpanDataIbuHamil(string nama, string usiaKehamilan, DateTime tanggalTrimester)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Database=ibu hamil;Port=5432;Password=Gun180106"))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO ibu_hamil (nama, usia_kehamilan, tanggal_trimester) VALUES (@nama, @usia, @tanggal)";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@nama", nama);
                        command.Parameters.AddWithValue("@usia", usiaKehamilan);
                        command.Parameters.AddWithValue("@tanggal", tanggalTrimester);
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
                catch 
                {
                    MessageBox.Show("Gagal menyimpan ke database: ");
                    return false;
                }
            }
        }





        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}


