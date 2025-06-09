using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace fitur_gejalaumum
{
    public class Obat
    {
        public string ObatKimia { get; set; }
        public string ObatHerbal { get; set; }
        public string Lifestyle { get; set; }

        public Obat(string obatKimia, string obatHerbal, string lifestyle)
        {
            ObatKimia = obatKimia;
            ObatHerbal = obatHerbal;
            Lifestyle = lifestyle;
        }

        public string TampilkanObat()
        {
            return $"Obat Kimia: {ObatKimia}, Obat Herbal: {ObatHerbal}, Lifestyle: {Lifestyle}";
        }
    }

}
