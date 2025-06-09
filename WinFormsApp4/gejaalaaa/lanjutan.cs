using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitur_gejalaumum
{

    public class Lanjutan : Konsultasi
    {
        public int Id { get; set; }
        public string GejalaLanjutan { get; set; }

        public Lanjutan(int id, string nama, int umur, string gejala, string kategori, string alergi, string gejalaLanjutan)
            : base(nama, umur, gejala, kategori, alergi)
        {
            Id = id;
            GejalaLanjutan = gejalaLanjutan;
        }
        public Lanjutan() : base("Unknown", 0, "", "", "")
        {
            Id = 0;
            GejalaLanjutan = "";
        }

        public override string TampilkanInfo()
        {
            return base.TampilkanInfo() + $", ID: {Id}, Gejala Lanjutan: {GejalaLanjutan}";
        }
    }
}
