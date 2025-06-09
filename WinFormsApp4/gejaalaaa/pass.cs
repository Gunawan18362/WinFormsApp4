using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fitur_gejalaumum;


namespace fitur_gejalaumum
{
    public class Pass : orang
    {
        public Pass(string nama, int umur) : base(nama, umur)
        {
        }

        public override string TampilkanInfo()
        {
            return $" Umur: {Umur}";
        }

        public string TentukanKategoriUmur()
        {
            if (Umur >= 4 && Umur <= 10)
                return "Anak-anak";
            else if (Umur >= 11 && Umur <= 17)
                return "Remaja";
            else if (Umur >= 18 && Umur <= 59)
                return "Dewasa";
            else if (Umur >= 60)
                return "Lansia";
            else
                return null;
        }
    }
}