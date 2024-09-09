using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriOtomasyonG060
{
    internal class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();
        public int ToplamArabaSayisi
        {
            get
            {
                int sayi = 0;
                foreach (Araba item in Arabalar)
                {
                    sayi++;
                }
                return sayi;
            }
        }
        public int KiradakiArabaSayisi
        {
            get
            {
                int adet = 0;
                foreach (Araba item in Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        adet++;
                    }
                }
                return adet;
            }
        }
        public int BekleyenArabaSayisi
        {
            get
            {
                int adet = 0;
                foreach (Araba item in Arabalar)
                {
                    if (item.Durum == DURUM.Galeride)
                    {
                        adet++;
                    }
                }
                return adet;
            }

            set
            {

            }
        }

        public int ToplamArabaKiralamaSuresi
        {
            get
            {
                int sure = 0;
                foreach (Araba item in Arabalar)
                {
                    sure += item.ToplamKiralanmaSuresi;
                }
                return sure;
            }
        }

        public int ToplamArabaKiralamaAdedi
        {
            get
            {
                int adet = 0;
                foreach (Araba item in Arabalar)
                {
                    adet += item.KiralanmaSayisi;
                }
                return adet;
            }
        }

        private int _ciro = 0;
        public int Ciro
        {
            get
            {
                return _ciro;
            }
            set
            {
                _ciro = value;
            }
        }

        public int FiyatHesapla(int kira, int sure)
        {
            return kira * sure;
        }

        public void ArabaKiralama(string plaka, int sure)
        {
            Araba araba = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    araba = item;
                    break;
                }
            }
            araba.Durum = DURUM.Kirada;
            araba.KiralanmaSureleri.Add(sure);
            araba.KiralanmaSayisi++;

            Ciro += FiyatHesapla(araba.KiralamaBedeli, sure);
        }

        public void ArabaTeslimAlma(string plaka)
        {
            Araba araba = null;
            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    araba = item;
                    break;
                }
            }
            araba.Durum = DURUM.Galeride;
        }

        public void KiradakiArabalarListe()
        {
            Console.WriteLine();
            Console.WriteLine("-Kiradaki Arabalar-\n");
            if (KiradakiArabaSayisi == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("-Kiradaki Arabalar-\n");
                Console.WriteLine("Plaka".PadRight(14) +
                                  "Marka".PadRight(12) +
                                  "K. Bedeli".PadRight(12) +
                                  "Araba Tipi".PadRight(12) +
                                  "K. Sayısı".PadRight(12) +
                                  "Durum".PadRight(12));
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (Araba item in Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        Console.WriteLine(item.Plaka.PadRight(14) +
                                          item.Marka.PadRight(12) +
                                          Convert.ToString(item.KiralamaBedeli).PadRight(12) +
                                          Convert.ToString(item.ArabaTipi).PadRight(12) +
                                          Convert.ToString(item.KiralanmaSayisi).PadRight(12) +
                                          Convert.ToString(item.Durum).PadRight(12));
                    }
                }
            }
        }

        public void GaleridekiArabalarıListe()
        {
            Console.WriteLine();
            Console.WriteLine("-Galerideki Arabalar-\n");
            if (BekleyenArabaSayisi == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                
                Console.WriteLine("Plaka".PadRight(14) +
                                  "Marka".PadRight(12) +
                                  "K. Bedeli".PadRight(12) +
                                  "Araba Tipi".PadRight(12) +
                                  "K. Sayısı".PadRight(12) +
                                  "Durum".PadRight(12));
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (Araba item in Arabalar)
                {
                    if (item.Durum == DURUM.Galeride)
                    {
                        Console.WriteLine(item.Plaka.PadRight(14) +
                                          item.Marka.PadRight(12) +
                                          Convert.ToString(item.KiralamaBedeli).PadRight(12) +
                                          Convert.ToString(item.ArabaTipi).PadRight(12) +
                                          Convert.ToString(item.KiralanmaSayisi).PadRight(12) +
                                          Convert.ToString(item.Durum).PadRight(12));
                    }
                }
            }
        }

        public void TümArabalarListe()
        {
            Console.WriteLine();
            Console.WriteLine("-Tüm Arabalar-");
            Console.WriteLine();
            if (Arabalar.Count == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("Plaka".PadRight(14) +
                                  "Marka".PadRight(12) +
                                  "K. Bedeli".PadRight(12) +
                                  "Araba Tipi".PadRight(12) +
                                  "K. Sayısı".PadRight(12) +
                                  "Durum".PadRight(12));
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (Araba item in Arabalar)
                {
                    Console.WriteLine(item.Plaka.PadRight(14) +
                                        item.Marka.PadRight(12) +
                                        Convert.ToString(item.KiralamaBedeli).PadRight(12) +
                                        Convert.ToString(item.ArabaTipi).PadRight(12) +
                                        Convert.ToString(item.KiralanmaSayisi).PadRight(12) +
                                        Convert.ToString(item.Durum).PadRight(12));
                }
            }
        }

        public void KiralamaIptal(string plaka)
        {
            Araba araba = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    araba = item;

                    break;
                }
            }
            if (araba.Durum == DURUM.Kirada)
            {
                araba.Durum = DURUM.Galeride;
                Ciro -= FiyatHesapla(araba.KiralamaBedeli, araba.KiralanmaSureleri.Last());
                araba.KiralanmaSureleri.RemoveAt(araba.KiralanmaSureleri.Count - 1);
                araba.KiralanmaSayisi--;

                Console.WriteLine("\nİptal gerçekleştirildi.");
            }
        }
        public void ArabaEkle(string plaka, string marka, int kira, ARABA_TIPI aTip, DURUM konum)
        {
            Araba arb = new Araba(plaka, marka, kira, aTip, konum);
            Arabalar.Add(arb);

        }

        public void ArabaSil(string plaka)
        {
            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    Arabalar.Remove(item);
                    Console.WriteLine();
                    Console.WriteLine("Araba silindi.");
                    break;
                }
            }
        }

        public void GaleriBilgi()
        {
            Console.WriteLine($"Toplam araba sayısı: {ToplamArabaSayisi}");
            Console.WriteLine($"Kiradaki araba sayısı: {KiradakiArabaSayisi}");
            Console.WriteLine($"Bekleyen araba sayısı: {BekleyenArabaSayisi}");
            Console.WriteLine($"Toplam araba kiralama süresi: {ToplamArabaKiralamaSuresi}");
            Console.WriteLine($"Toplam araba kiralama adedi: {ToplamArabaKiralamaAdedi} ");
            Console.WriteLine($"Ciro: {Ciro}");
        }

    }
}
