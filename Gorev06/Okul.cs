using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiG060
{
    //veriyi yöneteceğimiz kısım
    internal class Okul
    {
        public List<Ogrenci> Ogrenciler = new List<Ogrenci>();
        
        public void OgrenciEkleme(int no, string ad, string soyad, SUBE sube, CINSIYET cinsiyet, DateTime tarih)
        {
            this.Ogrenciler.Add(new Ogrenci(no, ad, soyad, sube, cinsiyet,tarih));
        }
        public void OgrenciSilme()
        {

        }
        public void OgrenciGuncelleme()
        {

        }
        public void OgrenciNotuGir(int no, string ders, float not)
        {
            DersNotu dn = new DersNotu(not, ders);
            Ogrenci o = this.Ogrenciler.Where(f=>f.No==no).FirstOrDefault();
            o.Notlar.Add(dn);
        }
    }
}
