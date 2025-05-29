using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class GantiProfil : Form
    {
        public GantiProfil()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usernameBaru = textBox2.Text.Trim();
            string usernameLamaInput = textBox1.Text.Trim();
            



            if (usernameLamaInput != User.Username)
            {
                MessageBox.Show("Username lama tidak cocok.", "Peringatan");
                return;
            }

            if (string.IsNullOrEmpty(usernameBaru))
            {
                MessageBox.Show("Username baru harus diisi, jika ingin dirubah.", "Peringatan");
                return;
            }

            if (usernameBaru == User.Username)
            {
                MessageBox.Show("Username yang baru tidak boleh sama dengan username lama.", "Peringatan");
                return;
            }

            var repo = new UserRepository();
            bool berhasil = repo.UpdateUsername(User.Id, usernameBaru);

            if (berhasil)
            {
                User.Username = usernameBaru; 
                MessageBox.Show("Username berhasil diubah!", "Sukses");
                this.Close();
            }
            else
            {
                MessageBox.Show("Gagal mengubah username di database.", "Error");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
