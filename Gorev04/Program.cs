using System;
using System.Collections.Generic;

namespace OgrenciYonetimUygulamasiG060
{
    internal class Program
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        static bool devam = true;
        static void Main(string[] args)
        {
            SahteVeriGir();
            Uygulama();
        }
        static void Uygulama()
        {
            Menu();

            while (devam)
            {
                string giris = SecimAl();
                switch (giris)
                {
                    case "1":
                    case "E":
                        OgrenciEkle(); break;
                    case "2":
                    case "L":
                        OgrenciListele(); break;
                    case "3":
                    case "S":
                        OgrenciSil(); break;
                    case "4":
                    case "X":
                        devam = false; break;
                    default:
                        break;
                }
            }
        }
        static void OgrenciSil()
        {
            Console.WriteLine("3 - Öğrenci Sil----------   ");

            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek öğrenci yok.");
            }
            else
            {
                Console.WriteLine("Silmek istediğiniz öğrencinin  ");
                Console.Write("No: ");
                int no = Convert.ToInt32(Console.ReadLine());
                Ogrenci o = null;
                foreach (Ogrenci item in ogrenciler)
                {
                    if (no == item.No)
                    {
                        o = item;
                    }
                }
                if (o != null)
                {
                    Console.WriteLine("Adı: " + o.Ad);
                    Console.WriteLine("Soyadı: " + o.Soyad);
                    Console.WriteLine("Şubesi: " + o.Sube);
                    Console.WriteLine();
                    Console.Write("Öğrenciyi silmek istediğinize emin misiniz? (E / H) ");
                    string secim = Console.ReadLine().ToUpper();
                    if (secim == "E")
                    {
                        ogrenciler.Remove(o);
                        Console.WriteLine("Öğrenci silindi. ");
                    }
                    else if (secim == "H")
                    {
                        Console.WriteLine(" Öğrenci silinmedi. ");
                    }
                }
                else
                {
                    Console.WriteLine("Listede bu numarada bir öğrenci yok.");
                }
                Console.WriteLine();
            }
        }
        static void OgrenciEkle()
        {
            Ogrenci o = new Ogrenci();

            Console.WriteLine("1 - Öğrenci Ekle ----------");
            Console.WriteLine((ogrenciler.Count+1) + ". Öğrencinin                ");
            bool noGecerli = false;
            while (!noGecerli)
            { 
                Console.Write("No: ");
                o.No = Convert.ToInt32(Console.ReadLine());
                foreach (Ogrenci ogr in ogrenciler)
                {
                    if (ogr.No == o.No)
                    {
                        Console.WriteLine("Geçersiz giriş. Bu no başka bir öğrenciye ait. Başka no girin.");
                        noGecerli = false;
                        break;
                    }
                    else
                    {
                        noGecerli = true;
                    }
                }
            }
            Console.Write("Adı: ");
            o.Ad = Console.ReadLine();
            o.Ad = (o.Ad).Substring(0, 1).ToUpper() + (o.Ad).Substring(1).ToLower();

            Console.Write("Soyadı: ");
            o.Soyad = Console.ReadLine();
            o.Soyad = (o.Soyad).Substring(0, 1).ToUpper() + (o.Soyad).Substring(1).ToLower();

            Console.Write("Şubesi: ");
            o.Sube = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Öğrenciyi kaydetmek istediğinize emin misiniz? (E / H)");
            string secim = Console.ReadLine();
            Console.WriteLine();
            if (secim.ToUpper() == "E")
            {
                ogrenciler.Add(o);
                Console.WriteLine("Öğrenci eklendi. ");
            }
            else if (secim.ToLower() == "h")
            {
                Console.WriteLine("Öğrenci eklenmedi.");
            }
            Console.WriteLine();

        }
        static void OgrenciListele()
        {
            Console.WriteLine("2 - Öğrenci Listele -----------     ");
            Console.WriteLine();
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Gösterilecek öğrenci yok.");
            }
            else
            {
                Console.WriteLine("Şube    No       Ad       Soyad  ");
                Console.WriteLine("---------------------------------- ");

                foreach (Ogrenci item in ogrenciler)
                {
                    Console.WriteLine(item.Sube.PadRight(2)+ "      " + item.No+ "      " + item.Ad.PadRight(7) + "  " + item.Soyad.PadRight(3));
                }
                Console.WriteLine();
            }   
        }
        static void SahteVeriGir()
        {
            Ogrenci o1 = new Ogrenci();
            o1.Sube = "A";
            o1.Ad = "A";
            o1.Soyad = "A";
            o1.No = 125;

            Ogrenci o2 = new Ogrenci();
            o2.Sube = "B";
            o2.Ad = "B";
            o2.Soyad = "B";
            o2.No = 225;

            Ogrenci o3 = new Ogrenci();
            o3.Sube = "C";
            o3.Ad = "C";
            o3.Soyad = "C";
            o3.No = 325;

            ogrenciler.Add(o1);
            ogrenciler.Add(o2);
            ogrenciler.Add(o3);
        }
        static void Menu()
        {
            Console.WriteLine("Öğrenci Yönetim Uygulaması");
            Console.WriteLine("1 - Öğrenci Ekle(E)       ");
            Console.WriteLine("2 - Öğrenci Listele(L)    ");
            Console.WriteLine("3 - Öğrenci Sil(S)        ");
            Console.WriteLine("4 - Çıkış(X)              ");
            Console.WriteLine();
        }
        static string SecimAl()
        {
            int sayac = 0;
            string giris = null;
            string istenen = "1E2L3S4X";
            while (sayac < 10)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                giris = Console.ReadLine();

                if (istenen.IndexOf(giris) == -1)
                {
                    Console.WriteLine("Hatalı giriş yapıldı.");
                    sayac++;
                    if (sayac == 10)
                    {
                        Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                        devam = false;
                    }
                }
                else
                {
                    break;
                }
            }
            return giris;
        }
    }
}
