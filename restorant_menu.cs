using System;

namespace Softito
{
    class Program
    {
        static int[] masalar = new int[10]; // 0: boş, 1: dolu
        static bool programCalisiyor = true;
        static int[,] masaAdetleri = new int[10, 5]; // her masa için ürünlerin adetleri
        static double[,] masaFiyatlari = new double[10, 5]; // masaya ait olan ürünlerin fiyatları
        static void Main()
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
                string anaMenuSecim = Console.ReadLine();

                if (anaMenuSecim == "1")
                {
                    // masa açma işlemleri
                    Console.WriteLine("\n=== MASA AÇ ===");
                    Console.WriteLine("[1] İç Mekan Masaları (1-5)");
                    Console.WriteLine("[2] Ön Bahçe Masaları (6-10)");
                    Console.WriteLine("[3] Tüm Masalar (1-10)");
                    Console.WriteLine("[0] Ana Menü");

                    Console.Write("\nSeçiminizi yapınız: ");
                    string masaSecim = Console.ReadLine();

                    if (masaSecim == "1")
                    {
                        for (int i = 0; i < 5; i++)
                            masalar[i] = 1; // içerdeki masalar
                        Console.WriteLine("İç mekan masaları açıldı.");
                    }
                    else if (masaSecim == "2")
                    {
                        for (int i = 5; i < 10; i++)
                            masalar[i] = 1; // sadece ön bahçe
                        Console.WriteLine("Ön bahçe masaları açıldı.");
                    }
                    else if (masaSecim == "3")
                    {
                        for (int i = 0; i < 10; i++)
                            masalar[i] = 1; // tüm masalar açıldı
                        Console.WriteLine("Tüm masalar açıldı.");
                    }
                    else if (masaSecim == "0")
                    {
                        continue; // ana menüye dönme
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim!");
                    }
                }
                else if (anaMenuSecim == "2")
                {
                    // masa işlem
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
                        bool devam = true;

                        while (devam)
                        {
                            Console.WriteLine("=== MENÜ ===");
                            Console.WriteLine("[1] İçecekler");
                            Console.WriteLine("[2] Yiyecekler");
                            Console.WriteLine("[0] Ana Menüye Dön");

                            Console.Write("\nSeçiminizi yapınız: ");
                            string menuSecim = Console.ReadLine();

                            if (menuSecim == "1")
                            {
                                // içecek menüsüne git
                                string[] icecekler = { "Espresso", "Filtre Kahve", "Frappuccino" };
                                double[] icecekFiyatlar = { 30, 25, 40 };

                                Console.WriteLine($"=== İçecekler ===");
                                for (int i = 0; i < icecekler.Length; i++)
                                {
                                    Console.WriteLine($"[{i + 1}] {icecekler[i]} - {icecekFiyatlar[i]} TL");
                                }
                                Console.WriteLine("[0] Ana Menüye Dön");

                                bool secimDevam = true;
                                while (secimDevam)
                                {
                                    Console.Write("\nSeçiminizi yapınız: ");
                                    string urunSecim = Console.ReadLine();
                                    if (int.TryParse(urunSecim, out int secim) && secim >= 1 && secim <= icecekler.Length)
                                    {
                                        Console.Write("Kaç adet almak istersiniz? ");
                                        int adet = int.Parse(Console.ReadLine());
                                        masaAdetleri[masaNo - 1, secim - 1] += adet;
                                        Console.WriteLine($"{icecekler[secim - 1]} - {adet} adet sipariş edildi.");
                                    }
                                    else if (urunSecim == "0")
                                    {
                                        secimDevam = false; // Ana menüye dön
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz seçim! Tekrar deneyin.");
                                    }
                                }
                            }
                            else if (menuSecim == "2")
                            {
                                // yiyecek menüsüne git
                                string[] yiyecekler = { "Cheesecake", "Pasta", "Muffin", "Kahvaltı", "Sandviç" };
                                double[] yiyecekFiyatlar = { 50, 45, 30, 60, 40 };

                                Console.WriteLine($"=== Yiyecekler ===");
                                for (int i = 0; i < yiyecekler.Length; i++)
                                {
                                    Console.WriteLine($"[{i + 1}] {yiyecekler[i]} - {yiyecekFiyatlar[i]} TL");
                                }
                                Console.WriteLine("[0] Ana Menüye Dön");

                                bool secimDevam = true;
                                while (secimDevam)
                                {
                                    Console.Write("\nSeçiminizi yapınız: ");
                                    string urunSecim = Console.ReadLine();
                                    if (int.TryParse(urunSecim, out int secim) && secim >= 1 && secim <= yiyecekler.Length)
                                    {
                                        Console.Write("Kaç adet almak istersiniz? ");
                                        int adet = int.Parse(Console.ReadLine());
                                        masaAdetleri[masaNo - 1, secim - 1] += adet;
                                        Console.WriteLine($"{yiyecekler[secim - 1]} - {adet} adet sipariş edildi.");
                                    }
                                    else if (urunSecim == "0")
                                    {
                                        secimDevam = false; // Ana menüye dön
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz seçim! Tekrar deneyin.");
                                    }
                                }
                            }
                            else if (menuSecim == "0")
                            {
                                devam = false; // menüden çıkış
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz tuş! Tekrar deneyin.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz masa seçimi!");
                    }
                }
                else if (anaMenuSecim == "3")
                {
                    // siparişler
                    Console.WriteLine("=== SİPARİŞLERİNİZ ===");
                    for (int i = 0; i < masalar.Length; i++)
                    {
                        if (masalar[i] == 1) // masa açık mı kontrol et
                        {
                            Console.WriteLine($"\nMasa {i + 1}:");
                            double toplamTutar = 0;
                            for (int j = 0; j < 5; j++)
                            {
                                if (masaAdetleri[i, j] > 0)
                                {
                                    string[] urunAdlari = { "Espresso", "Filtre Kahve", "Frappuccino", "Cheesecake", "Pasta" };
                                    double[] fiyatlar = { 30, 25, 40, 50, 45 };

                                    Console.WriteLine($"{urunAdlari[j]} - {masaAdetleri[i, j]} adet - {fiyatlar[j]} TL");
                                    toplamTutar += masaAdetleri[i, j] * fiyatlar[j];
                                }

                            }
                            Console.WriteLine($"Toplam Tutar: {toplamTutar} TL");
                        }
                    }
                }
                else if (anaMenuSecim == "4")
                {
                    // Kasa işlemi
                    Console.WriteLine("\n=== KASA İŞLEMİ ===");
                    Console.Write("Kapatmak istediğiniz masa numarasını giriniz (1-10): ");
                    
                    if (int.TryParse(Console.ReadLine(), out int masaNo) && masaNo >= 1 && masaNo <= 10 && masalar[masaNo - 1] == 1)
                    {
                        double toplamTutar = 0;
                        
                        // Ürün adları ve fiyatları dizileri
                        string[] urunAdlari = { "Espresso", "Filtre Kahve", "Frappuccino", "Cheesecake", "Pasta" };
                        double[] fiyatlar = { 30, 25, 40, 50, 45 };
                        
                        // Masa ürünlerini listele
                        for (int i = 0; i < urunAdlari.Length; i++)
                        {
                            int adet = masaAdetleri[masaNo - 1, i];
                            if (adet > 0)
                            {
                                double fiyat = fiyatlar[i];
                                toplamTutar += adet * fiyat;
                                Console.WriteLine($"{urunAdlari[i]} - {adet} adet - {fiyat} TL");
                            }
                        }
                
                        // Toplam tutarı yazdır
                        Console.WriteLine($"Toplam Tutar: {toplamTutar} TL");
                
                        // Ödeme onayı
                        Console.Write("Ödeme alındı mı? (E/H): ");
                        if (Console.ReadLine().Trim().ToUpper() == "E")
                        {
                            masalar[masaNo - 1] = 0; // Masa kapandı
                            Console.WriteLine($"Masa {masaNo} kapandı ve ödeme alındı.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz masa numarası.");
                    }
                }

                else if (anaMenuSecim == "0")
                {
                    programCalisiyor = false; // çıkış
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim.");
                }
            }
        }
    }
}
