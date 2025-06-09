using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace fitur_gejalaumum
{
    public abstract class orang
    {
        private string nama;
        private int umur;

        public string Nama
        {
            get => nama;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    nama = "";
                  
                }
                else
                {
                    nama = value;
                }
            }
        }

        public int Umur
        {
            get => umur;
            set
            {
                if (value < 0)
                {
                    umur = 0;
                }
                else
                {
                    umur = value;
                }
            }
        }


        public orang(string nama, int umur)
        {
            Nama = nama;
            Umur = umur;
        }

        public abstract string TampilkanInfo();
    }
}
