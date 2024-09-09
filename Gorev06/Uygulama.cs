using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiG060
{
    //kullanıcı etkileşimi 
    internal class Uygulama
    {
        Okul OkulG060 = new Okul();
        public void Calistir() //akışı yazdığımız metot
        {
            Menu();
            while (true)
            {
                string secim = SecimAl();
                switch (secim)
                {
                    default:
                        break;
                }
            }
        }
        public void Menu()
        {

        }
        public string SecimAl()
        {

        }
        public void OgrenciEkle()
        {
            Console.Write("numarası: ");
            int no;
            Console.Write("adı: ");
            string ad;
            Console.Write("soyadı: ");
            string soyad;

            Console.Write("dogum tarihi: ");
            DateTime tarih;

            Console.Write("cinsiyeti(K/ E): ");
            CINSIYET cins;

            Console.Write("subesi(A/ B / C):");
            SUBE sube = SUBE.Empty;

            OkulG060.OgrenciEkleme(no, ad, soyad, sube, cins, tarih);

            Console.WriteLine("12 numaralı ögrenci sisteme başarılı bir şekilde eklenmistir.");
            Console.WriteLine("Sistemde 11 numaralı öğrenci olduğu için verdiğiniz öğrenci no 12 olarak değiştirildi.");

        }
        public void OgrenciSil()
        {

        }
        public void OgrenciGuncelle()
        {

        }

        public void SahteVeriGir()
        {
            OkulG060.OgrenciEkleme(1, "A", "B", SUBE.C, CINSIYET.Kiz, new DateTime(2007, 11, 13));
            OkulG060.OgrenciEkleme(1, "A", "B", SUBE.C, CINSIYET.Kiz, new DateTime(2007, 11, 13));
            OkulG060.OgrenciEkleme(1, "A", "B", SUBE.C, CINSIYET.Kiz, new DateTime(2007, 11, 13));
            OkulG060.OgrenciEkleme(1, "A", "B", SUBE.C, CINSIYET.Kiz, new DateTime(2007, 11, 13));
            OkulG060.OgrenciEkleme(1, "A", "B", SUBE.C, CINSIYET.Kiz, new DateTime(2007, 11, 13));
            OkulG060.OgrenciEkleme(1, "A", "B", SUBE.C, CINSIYET.Kiz, new DateTime(2007, 11, 13));
            OkulG060.OgrenciEkleme(1, "A", "B", SUBE.C, CINSIYET.Kiz, new DateTime(2007, 11, 13));
            OkulG060.OgrenciEkleme(1, "A", "B", SUBE.C, CINSIYET.Kiz, new DateTime(2007, 11, 13));
            OkulG060.OgrenciEkleme(1, "A", "B", SUBE.C, CINSIYET.Kiz, new DateTime(2007, 11, 13));
            OkulG060.OgrenciEkleme(1, "A", "B", SUBE.C, CINSIYET.Kiz, new DateTime(2007, 11, 13));
            OkulG060.OgrenciEkleme(1, "A", "B", SUBE.C, CINSIYET.Kiz, new DateTime(2007, 11, 13));
        }
        public void NotGir()
        {
            Console.WriteLine("20 - Not Gir-----------------------------------");
            Console.Write("Ögrencinin numarasi: ");
            int no;
            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine();
            Console.Write("Not eklemek istediğiniz ders: ");
            string dersAdi;
            Console.Write("Eklemek istediginiz not adedi: ");
            int adet = 10;
            for (int i = 0; i < adet; i++)
            {
                Console.Write(i + 1 + ". Notu girin: ");
                float not;
                OkulG060.OgrenciNotuGir(no, dersAdi,not);

            }
            Console.Write("Bilgiler sisteme girilmistir.                  ");
            Console.Write("                                               ");
        }
    }
}
