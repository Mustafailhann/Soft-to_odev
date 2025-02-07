using System;

namespace Softito
{
    class Program
    {
        static int[] masalar = new int[10]; // 0: boş, 1: dolu
        static bool programCalisiyor = true;
        static int[,] masaAdetleri = new int[10, 5]; // Her masa için 5 farklı ürüne ait adetler
        static double[,] masaFiyatlari = new double[10, 5]; // Her masa için 5 farklı ürüne ait fiyatlar

        static void Main()
        {
            AnaMenu();
        }

        static void AnaMenu()
        {
            while (programCalisiyor)
            {
                Console.WriteLine("\n=== ANA MENÜ ===");
                Console.WriteLine("[1] Masa Aç");
                Console.WriteLine("[2] Masa İşlem");
                Console.WriteLine("[3] Masa Hesap");
                Console.WriteLine("[4] Kasa İşlemi");
                Console.WriteLine("[0] Çıkış");

                Console.Write("\nSeçiminizi yapınız: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1": MasaAc(); break;
                    case "2": MasaIslem(); break;
                    case "3": SiparisleriGoster(); break;
                    case "4": KasaIslemi(); break;
                    case "0":
                        Console.WriteLine("Çıkış yapılıyor...");
                        programCalisiyor = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim! Tekrar deneyin.");
                        break;
                }
            }
        }

        static void KasaIslemi()
        {
            Console.WriteLine("\n=== KASA İŞLEMİ ===");
            Console.Write("Kapatmak istediğiniz masa numarasını giriniz (1-10): ");
            if (int.TryParse(Console.ReadLine(), out int masaNo) && masaNo >= 1 && masaNo <= 10 && masalar[masaNo - 1] == 1)
            {
                double toplamTutar = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (masaAdetleri[masaNo - 1, i] > 0)
                    {
                        string urunAdi = i < 3 ? (i == 0 ? "Espresso" : i == 1 ? "Filtre Kahve" : "Frappuccino") : (i == 3 ? "Cheesecake" : "Pasta");
                        double fiyat = i < 3 ? (i == 0 ? 30 : i == 1 ? 25 : 40) : (i == 3 ? 50 : 45);
                        toplamTutar += masaAdetleri[masaNo - 1, i] * fiyat;
                        Console.WriteLine($"{urunAdi} - {masaAdetleri[masaNo - 1, i]} adet - {fiyat} TL");
                    }
                }
                Console.WriteLine($"Toplam Tutar: {toplamTutar} TL");

                Console.Write("Ödeme alındı mı? (E/H): ");
                string onay = Console.ReadLine();
                if (onay.ToUpper() == "E")
                {
                    masalar[masaNo - 1] = 0; // Masayı kapat
                    for (int i = 0; i < 5; i++)
                    {
                        masaAdetleri[masaNo - 1, i] = 0; // Siparişleri sil
                        masaFiyatlari[masaNo - 1, i] = 0; // Fiyatları sıfırla
                    }
                    Console.WriteLine("Masa kapatıldı ve ödeme alındı.");
                }
                else
                {
                    Console.WriteLine("İşlem iptal edildi.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz masa seçimi!");
            }
        }

        static void MasaAc()
        {
            Console.WriteLine("\n=== MASA AÇ ===");
            Console.WriteLine("[1] İç Mekan Masaları (1-5)");
            Console.WriteLine("[2] Ön Bahçe Masaları (6-10)");
            Console.WriteLine("[3] Tüm Masalar (1-10)");
            Console.WriteLine("[0] Ana Menü");

            Console.Write("\nSeçiminizi yapınız: ");
            string secim = Console.ReadLine();

            if (secim == "1") { MasaAcYardım(0, 5); }
            else if (secim == "2") { MasaAcYardım(5, 10); }
            else if (secim == "3") { MasaAcYardım(0, 10); }
            else if (secim != "0") { Console.WriteLine("Geçersiz seçim!"); }
        }

        static void MasaAcYardım(int baslangic, int bitis)
        {
            for (int i = baslangic; i < bitis; i++)
                masalar[i] = 1; // Masayı aç

            Console.WriteLine("Masalar açıldı.");
        }

        static void MasaIslem()
        {
            Console.WriteLine("\n=== MASA İŞLEM ===");
            Console.WriteLine("Açık Masalar:");
            for (int i = 0; i < masalar.Length; i++)
            {
                if (masalar[i] == 1)
                    Console.WriteLine($"{i + 1}. Masa (Açık)");
            }

            Console.Write("Bir masa seçin: ");
            if (int.TryParse(Console.ReadLine(), out int masaNo) && masaNo >= 1 && masaNo <= 10 && masalar[masaNo - 1] == 1)
            {
                MenuGoster(masaNo);
            }
            else
            {
                Console.WriteLine("Geçersiz masa seçimi!");
            }
        }

        static void MenuGoster(int masaNo)
        {
            bool menuDevam = true;
            while (menuDevam)
            {
                Console.WriteLine("=== MENÜ ===");
                Console.WriteLine("[1] İçecekler");
                Console.WriteLine("[2] Yiyecekler");
                Console.WriteLine("[0] Ana Menüye Dön");

                Console.Write("\nSeçiminizi yapınız: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1": IcecekMenusu(masaNo); break;
                    case "2": YiyecekMenusu(masaNo); break;
                    case "0": menuDevam = false; break;
                    default: Console.WriteLine("Geçersiz tuş! Tekrar deneyin."); break;
                }
            }
        }

        static void IcecekMenusu(int masaNo)
        {
            UrunSec(masaNo, "İçecekler", new string[] { "Espresso", "Filtre Kahve", "Frappuccino" }, new double[] { 30, 25, 40 });
        }

        static void YiyecekMenusu(int masaNo)
        {
            UrunSec(masaNo, "Yiyecekler", new string[] { "Cheesecake", "Pasta", "Muffin", "Kahvaltı", "Sandviç" }, new double[] { 50, 45, 30, 60, 40 });
        }

        static void UrunSec(int masaNo, string kategori, string[] urunler, double[] fiyatlar)
        {
            bool siparisDevam = true;
            while (siparisDevam)
            {
                Console.WriteLine($"=== {kategori} ===");
                for (int i = 0; i < urunler.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {urunler[i]} ({fiyatlar[i]} TL)");
                }
                Console.WriteLine("0 - Siparişi Tamamla");

                Console.Write("\nSeçiminizi yapınız: ");
                if (int.TryParse(Console.ReadLine(), out int secim) && secim > 0 && secim <= urunler.Length)
                {
                    string urunAdi = urunler[secim - 1];
                    double fiyat = fiyatlar[secim - 1];

                    Console.Write("Kaç adet almak istiyorsunuz? ");
                    if (int.TryParse(Console.ReadLine(), out int adet) && adet > 0)
                    {
                        int urunIndex = Array.IndexOf(urunler, urunAdi);
                        masaAdetleri[masaNo - 1, urunIndex] += adet;
                        masaFiyatlari[masaNo - 1, urunIndex] += fiyat * adet;

                        Console.WriteLine($"{adet} adet {urunAdi} eklendi!");
                    }
                    else
                        Console.WriteLine("Geçersiz adet!");
                }
                else if (secim == 0)
                {
                    siparisDevam = false;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim!");
                }
            }
        }

        static void SiparisleriGoster()
        {
            Console.WriteLine("=== SİPARİŞLERİNİZ ===");
            for (int i = 0; i < masalar.Length; i++)
            {
                if (masalar[i] == 1) // Eğer masa açıksa
                {
                    Console.WriteLine($"\nMasa {i + 1}:");
                    double toplamTutar = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (masaAdetleri[i, j] > 0)
                        {
                            string urunAdi = j < 3 ? (j == 0 ? "Espresso" : j == 1 ? "Filtre Kahve" : "Frappuccino") : (j == 3 ? "Cheesecake" : "Pasta");
                            double fiyat = j < 3 ? (j == 0 ? 30 : j == 1 ? 25 : 40) : (j == 3 ? 50 : 45);
                            Console.WriteLine($"{urunAdi} - {masaAdetleri[i, j]} adet - {fiyat} TL");
                            toplamTutar += masaAdetleri[i, j] * fiyat;
                        }
                    }
                    Console.WriteLine($"Toplam Tutar: {toplamTutar} TL");
                }
            }
        }
    }
}
