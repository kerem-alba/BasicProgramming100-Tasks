using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OtoGaleriOtomasyonG060
{
    internal class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public int KiralamaBedeli { get; set; }
        public ARABA_TIPI ArabaTipi { get; set; }
        public DURUM Durum { get; set; }
        public int KiralanmaSayisi { get; set; }
        
        public int ToplamKiralanmaSuresi 
        { 
            get
            {
                int toplam = 0;
                foreach (int sure in KiralanmaSureleri)
                {
                    toplam += sure;
                }
                return toplam;
            }
        }

        public List<int> KiralanmaSureleri = new List<int>();

        public Araba(string plaka, string marka, int kira, ARABA_TIPI aTipi, DURUM konum)
        {
            this.Plaka = plaka;
            this.Marka = marka;
            this.KiralamaBedeli = kira;
            this.ArabaTipi = aTipi;
            this.Durum =DURUM.Galeride;
        }
        public static bool PlakaDogrulaTR(string plaka)
        {
            string desen = @"^[0-9]{2}[A-Z]{2,3}[0-9]{2,4}$";
            string ozelDesen = @"^[0-9]{2}[A-Z]{1}[0-9]{4}$";

            if (Regex.IsMatch(plaka, desen) || Regex.IsMatch(plaka, ozelDesen))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public enum ARABA_TIPI
    {
        Empty,
        SUV=1,
        Hatchback,
        Sedan
    }
    public enum DURUM
    {
        Empty, Galeride, Kirada
    }
}
