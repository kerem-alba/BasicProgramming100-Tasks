using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiG060
{
    internal class Ogrenci
    {
        public int No { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public CINSIYET Cinsiyet { get; set; }
        public SUBE Sube { get; set; }
        public float Ortalama { get; set; }
        public Adres Adresi { get; set; }

        public List<string> Kitaplar = new List<string>();
        public List<DersNotu> Notlar = new List<DersNotu>();
        public Ogrenci(int no, string ad, string soyad, SUBE sb, CINSIYET cins, DateTime dTarihi)
        {
            this.No = no;
            this.Ad = ad;
            this.Soyad = soyad;
            this.Cinsiyet = cins;
            this.DogumTarihi = dTarihi;
            this.Sube = sb;
            this.Adresi = new Adres();
        }

    }
    public enum SUBE
    {
        Empty, A, B, C, D
    }
    public enum CINSIYET
    {
        Empty, Kiz, Erkek
    }
}
