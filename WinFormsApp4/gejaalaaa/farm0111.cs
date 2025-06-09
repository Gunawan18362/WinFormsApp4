using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitur_gejalaumum
{
    public partial class farm0111 : Form
    {
        private string obatKimia;
        private string kategoriLanjutan;
        public farm0111(string obatKimia, string kategoriLanjutan)
        {
            InitializeComponent();
            this.obatKimia = obatKimia;
            this.kategoriLanjutan = kategoriLanjutan;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void farm0111_Load(object sender, EventArgs e)
        {
            label1.Text = $"Obat Kimia: {obatKimia}";
            label2.Text = $"Rekomendasi: {kategoriLanjutan}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(new Lanjutan(0, "", 0, "", "", "", ""));
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}
