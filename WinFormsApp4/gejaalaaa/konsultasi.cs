using System;

namespace fitur_gejalaumum
{
    public class Konsultasi : orang
    {
        public string Gejala { get; set; }
        public string Kategori { get; set; }
        public string Alergi { get; set; }

        public Konsultasi(string nama, int umur, string gejala, string kategori, string alergi)
            : base(nama, umur)
        {
            Gejala = gejala;
            Kategori = kategori;
            Alergi = alergi;
        }

        public override string TampilkanInfo()
        {
            return $"Nama: {Nama}, Umur: {Umur}, Gejala: {Gejala}, Kategori: {Kategori}, Alergi: {Alergi}";
        }
    }
}
