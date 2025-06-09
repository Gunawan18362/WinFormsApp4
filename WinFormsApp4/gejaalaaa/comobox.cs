using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitur_gejalaumum
{
    public class comobox
    {
        public static class DataCombo
        {
            public static List<string> GejalaList = new List<string>()
            {
            "DEMAM",
            "BATUK",
            "FLU",
            "PUSING",
            "MUAL",
            "NYERI OTOT"
            };

            public static List<string> AlergiList = new List<string>()
        {
            "TIDAK ADA",
            "RUAM",
            "DOIS TINGGI",
            "MAKAN",
            "UDARA DINGIN"
        };

            public static List<string> KategoriList = new List<string>()
        {
            "RINGAN",
            "SEDANG",
            "BERAT"
        };
        }
    }
}
