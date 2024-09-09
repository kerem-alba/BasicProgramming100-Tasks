using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

namespace OtoGaleriOtomasyonG060
{
    internal class Program
    {
        static Galeri G060Galerisi = new Galeri();
        static public int cikisSayaci = 0;

        static void Main(string[] args)
        {
            SahteVeriGir();
            Uygulama();
        }

        static void SahteVeriGir()
        {
            G060Galerisi.ArabaEkle("34ARB3434", "FIAT", 70, ARABA_TIPI.Sedan, DURUM.Galeride);
            G060Galerisi.ArabaEkle("35ARB3535", "KIA", 60, ARABA_TIPI.SUV, DURUM.Galeride);
            G060Galerisi.ArabaEkle("34US2342", "OPEL", 50, ARABA_TIPI.Hatchback, DURUM.Galeride);
        }

        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                      ");
            Console.WriteLine("1- Araba Kirala (K)                   ");
            Console.WriteLine("2- Araba Teslim Al (T)                ");
            Console.WriteLine("3- Kiradaki Arabaları Listele (R)     ");
            Console.WriteLine("4- Galerideki Arabaları Listele (M)   ");
            Console.WriteLine("5- Tüm Arabaları Listele (A)          ");
            Console.WriteLine("6- Kiralama İptali (I)                ");
            Console.WriteLine("7- Araba Ekle (Y)                     ");
            Console.WriteLine("8- Araba Sil (S)                      ");
            Console.WriteLine("9- Bilgileri Göster (G)               ");
        }

        static void Uygulama()
        {
            Menu();
            SecimAl();
        }
        static void Hata()
        {
            cikisSayaci++;
            if (cikisSayaci == 10) { Environment.Exit(0); }
        }
        static string SecimAl()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine().ToUpper();
                switch (secim)
                {
                    case "1":
                    case "K":
                        ArabaKirala(); break;

                    case "2":
                    case "T":
                        ArabaTeslimAl(); break;

                    case "3":
                    case "R":
                        KiradakiArabalarListe(); break;

                    case "4":
                    case "M":
                        GaleridekiArabalarListe(); break;

                    case "5":
                    case "A":
                        TümArabalarListe(); break;

                    case "6":
                    case "I":
                        KiralamaIptal(); break;

                    case "7":
                    case "Y":
                        ArabaEkle(); break;

                    case "8":
                    case "S":
                        ArabaSil(); break;

                    case "9":
                    case "G":
                        BilgileriGöster(); break;

                    case "X":
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                        Hata();
                        break;
                }
            }
        }
        static void ArabaKirala()
        {
            Console.WriteLine();
            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine();

            int sure = 0;
            string plaka = "";
            bool PlakaVarMi;
            bool KiradaMi;
            if (G060Galerisi.ToplamArabaSayisi == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");
            }
            else if (G060Galerisi.BekleyenArabaSayisi == 0)
            {
                Console.WriteLine("Tüm araçlar kirada.");
            }
            else
            {
                do
                {
                    PlakaVarMi = false;
                    KiradaMi = false;
                    Console.Write("Kiralanacak arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();
                    switch (plaka)
                    {
                        case "X":
                            SecimAl(); break;
                        default:
                            break;
                    }
                    Araba araba = null;
                    foreach (Araba item in G060Galerisi.Arabalar)
                    {
                        if (item.Plaka == plaka)
                        {
                            PlakaVarMi = true;
                            araba = item;
                            if (item.Durum == DURUM.Kirada)
                            {
                                KiradaMi = true;
                                Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                            }
                        }
                    }

                    if (!Araba.PlakaDogrulaTR(plaka))
                    {
                        Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    }
                    if (araba == null && Araba.PlakaDogrulaTR(plaka))
                    {
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    }

                } while (!Araba.PlakaDogrulaTR(plaka) || !PlakaVarMi || KiradaMi);

                bool sureGecerli = false;

                do
                {
                    Console.Write("Kiralama süresi: ");
                    string giris = Console.ReadLine();

                    if (int.TryParse(giris, out sure))
                    {
                        sureGecerli = true;
                    }
                    else
                    {
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                    }
                } while (!sureGecerli);

                Console.WriteLine();
                Console.WriteLine($"{plaka} plakalı araba {sure} saatliğine kiralandı.");

                G060Galerisi.ArabaKiralama(plaka, sure);
            }
        }
        static void ArabaTeslimAl()
        {
            Console.WriteLine();
            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine();
            string plaka = "";
            bool plakaVarMi;
            bool galerideMi;
            Araba araba = null;
            if (G060Galerisi.ToplamArabaSayisi == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");
            }
            else if (G060Galerisi.KiradakiArabaSayisi == 0)
            {
                Console.WriteLine("Kirada hiç araba yok.");
            }
            else
            {
                do
                {
                    plakaVarMi = false;
                    galerideMi = false;
                    Console.Write("Teslim edilecek arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();
                    switch (plaka)
                    {
                        case "X":
                            SecimAl(); break;
                        default:
                            break;
                    }
                    foreach (Araba item in G060Galerisi.Arabalar)
                    {
                        if (item.Plaka == plaka)
                        {
                            plakaVarMi = true;
                            araba = item;
                            if (item.Durum == DURUM.Galeride)
                            {
                                galerideMi = true;
                                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (!Araba.PlakaDogrulaTR(plaka))
                    {
                        Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    }
                    if (!plakaVarMi && Araba.PlakaDogrulaTR(plaka))
                    {
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    }



                } while (!Araba.PlakaDogrulaTR(plaka) || !plakaVarMi || galerideMi);

                araba.Durum = DURUM.Galeride;
                Console.WriteLine();
                Console.WriteLine("Araba galeride beklemeye alındı.");
            }
        }
        static void KiradakiArabalarListe()
        {
            G060Galerisi.KiradakiArabalarListe();
        }
        static void GaleridekiArabalarListe()
        {
            G060Galerisi.GaleridekiArabalarıListe();
        }
        static void TümArabalarListe()
        {
            G060Galerisi.TümArabalarListe();
        }
        static void KiralamaIptal()
        {
            bool plakaVarMi;
            bool galerideMi;
            string plaka = "";
            Console.WriteLine();
            Console.WriteLine("-Kiralama İptali-");
            Console.WriteLine();

            if (G060Galerisi.KiradakiArabaSayisi == 0)
            {
                Console.WriteLine("Kirada araba yok.");
            }
            else
            {
                do
                {
                    plakaVarMi = false;
                    galerideMi = false;
                    Console.Write("Kiralaması iptal edilecek arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();
                    switch (plaka)
                    {
                        case "X":
                            SecimAl(); break;
                        default:
                            break;
                    }
                    Araba araba = null;
                    foreach (Araba item in G060Galerisi.Arabalar)
                    {
                        if (item.Plaka == plaka)
                        {
                            plakaVarMi = true;
                            araba = item;
                            if (item.Durum == DURUM.Kirada)
                            {
                                G060Galerisi.KiralamaIptal(plaka);
                                continue;
                            }
                            else if (item.Durum == DURUM.Galeride)
                            {
                                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride. ");
                                galerideMi = true;
                                continue;
                            }
                        }
                    }
                    if (!Araba.PlakaDogrulaTR(plaka))
                    {
                        Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                        continue;
                    }
                    if (araba == null)
                    {
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    }

                } while (!Araba.PlakaDogrulaTR(plaka) || !plakaVarMi || galerideMi);
            }
        }
        static void ArabaEkle()
        {
            Console.WriteLine();
            Console.WriteLine("-Araba Ekle- ");
            Console.WriteLine();
            string plaka;
            bool PlakaVarMi;
            do
            {
                Console.Write("Plaka: ");
                plaka = Console.ReadLine().ToUpper();
                switch (plaka)
                {
                    case "X":
                        SecimAl(); break;
                    default:
                        break;
                }
                PlakaVarMi = false;

                foreach (Araba item in G060Galerisi.Arabalar)
                {
                    if (item.Plaka == plaka)
                    {
                        PlakaVarMi = true;
                        break;
                    }
                }

                if (!Araba.PlakaDogrulaTR(plaka))
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                }

                else if (PlakaVarMi)
                {
                    Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin.");
                }

            } while (!Araba.PlakaDogrulaTR(plaka) || PlakaVarMi);

            string marka;
            bool tumuSayi = false;
            do
            {
                Console.Write("Marka: ");
                marka = Console.ReadLine().ToUpper();

                tumuSayi = marka.All(char.IsDigit) && marka != "";
                switch (marka)
                {
                    case "X":
                        SecimAl(); break;
                    default:
                        break;
                }
                if (tumuSayi)
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                }
            } while (tumuSayi);

            int kBedeli;
            bool kBedeliGecerli = false;
            do
            {
                Console.Write("Kiralama Bedeli: ");
                string kBedeliStr = Console.ReadLine();
                switch (kBedeliStr)
                {
                    case "X":
                        SecimAl(); break;
                    default:
                        break;
                }
                kBedeliGecerli = int.TryParse(kBedeliStr, out kBedeli);
                if (!kBedeliGecerli)
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                }
            } while (!kBedeliGecerli);

            Console.WriteLine("Araba Tipi: ");
            Console.WriteLine("SUV için 1 ");
            Console.WriteLine("Hatchback için 2");
            Console.WriteLine("Sedan için 3    ");


            ARABA_TIPI aracTip = ARABA_TIPI.Empty;
            do
            {
                Console.Write("Araba Tipi: ");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        aracTip = ARABA_TIPI.SUV;
                        break;
                    case "2":
                        aracTip = ARABA_TIPI.Hatchback;
                        break;
                    case "3":
                        aracTip = ARABA_TIPI.Sedan;
                        break;
                    case "X":
                        SecimAl(); break;

                    default:
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                        break;

                }

            } while (aracTip == ARABA_TIPI.Empty);

            DURUM konum = DURUM.Galeride;
            G060Galerisi.ArabaEkle(plaka, marka, kBedeli, aracTip, konum);
            Console.WriteLine();
            Console.WriteLine("Araba başarılı bir şekilde eklendi.");

        }
        static void ArabaSil()
        {
            Console.WriteLine();
            Console.WriteLine("-Araba Sil-");
            Console.WriteLine();

            string plaka = "";
            bool PlakaVarMi;
            bool KiradaMi;
            if (G060Galerisi.BekleyenArabaSayisi == 0)
            {
                Console.WriteLine("Galeride silinecek araba yok.");
            }
            else
            {
                do
                {
                    PlakaVarMi = false;
                    KiradaMi = false;
                    Console.Write("Silinmek istenen arabanın plakasını giriniz: ");
                    plaka = Console.ReadLine().ToUpper();
                    switch (plaka)
                    {
                        case "X":
                            SecimAl(); break;
                        default:
                            break;
                    }
                    Araba araba = null;
                    foreach (Araba item in G060Galerisi.Arabalar)
                    {
                        if (item.Plaka == plaka)
                        {
                            PlakaVarMi = true;
                            araba = item;
                            if (item.Durum == DURUM.Kirada)
                            {
                                KiradaMi = true;
                                Console.WriteLine("Araba kirada olduğu için silme işlemi gerçekleştirilemedi.");
                            }
                        }
                    }

                    if (!Araba.PlakaDogrulaTR(plaka))
                    {
                        Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    }
                    if (araba == null && Araba.PlakaDogrulaTR(plaka))
                    {
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    }

                } while (!Araba.PlakaDogrulaTR(plaka) || !PlakaVarMi || KiradaMi);


                G060Galerisi.ArabaSil(plaka);

            }

        }
        static void BilgileriGöster()
        {
            Console.WriteLine();
            Console.WriteLine("-Galeri Bilgileri-");
            G060Galerisi.GaleriBilgi();
        }
    }
}
