using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIHUYYY
{
    class Database
    {
        public List<Mahasiswa> daftarMahasiswa = [new Mahasiswa("Sopo", "3051"), new Mahasiswa("Udud", "5130")];
    }
}
public class Mahasiswa
{
    public string nama, nim;
    public Mahasiswa(
        string nama, string nim)
    {
        this.nama = nama;
        this.nim = nim;
    }
}
