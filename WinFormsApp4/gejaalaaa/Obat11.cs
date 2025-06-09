using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitur_gejalaumum
{
    public class Obat11 : Obat
    {
        public string KategoriLanjutan { get; set; }

        public Obat11(string ObatKimia, string ObatHerbal, string Lifestyle, string kategoriLanjutan)
            : base(ObatKimia, ObatHerbal, Lifestyle)
        {
            KategoriLanjutan = kategoriLanjutan;
        }

        public string InfoObatLanjutan()
        {
            return $"{TampilkanObat()}, Kimia: {ObatKimia}, Kategori Lanjutan: {KategoriLanjutan}";
        }
    }

}
