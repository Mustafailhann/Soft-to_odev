int bakiye = 10000;
int dogruSifre = 1234;
int girisHakki = 3;
bool girisBasarili = false;

while (girisHakki > 0)
{
    Console.Write("Lütfen şifre girin: ");
    int girilenSifre = int.Parse(Console.ReadLine());

    if (girilenSifre == dogruSifre)
    {
        Console.WriteLine("Giriş başarılı.");
        girisBasarili = true;
        break; 
    }
    else
    {
        girisHakki--;
        Console.WriteLine("Hatalı şifre.");
        if (girisHakki > 0)
        {
            Console.WriteLine($"Kalan hakkınız: {girisHakki}");
        }
        else
        {
            Console.WriteLine("3 defa hatalı giriş yaptınız.");
            return; 
        }
    }
}

if (girisBasarili)
{
    while (true) 
    {
        Console.WriteLine("\nLütfen istediğiniz işlemi seçiniz:");
        Console.WriteLine("1 - Bakiye Görüntüle");
        Console.WriteLine("2 - Para Çekme");
        Console.WriteLine("3 - Para Gönderme");
        Console.WriteLine("4 - Çıkış");

        int secim = int.Parse(Console.ReadLine());

        if (secim == 1)
        {
            Console.WriteLine("Hesabınızdaki bakiye: " + bakiye);
        }
        else if (secim == 2)
        {
            Console.Write("Çekmek istediğiniz tutarı girin: ");
            int cekilentutar = int.Parse(Console.ReadLine());

            if (cekilentutar <= bakiye)
            {
                bakiye -= cekilentutar;
                Console.WriteLine("Para çekme işlemi başarılı. Kalan bakiye: " + bakiye);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye. Lütfen geçerli bir tutar giriniz.");
            }
        }
        else if (secim == 3)
        {
            Console.Write("Göndermek istediğiniz tutarı girin: ");
            int gönderilecekTutar = int.Parse(Console.ReadLine());

            if (gönderilecekTutar <= bakiye)
            {
                bakiye -= gönderilecekTutar;
                Console.WriteLine("Para gönderme işlemi başarılı. Kalan bakiye: " + bakiye);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye. Lütfen geçerli bir tutar giriniz.");
            }
        }
        else if (secim == 4)
        {
            Console.WriteLine("Çıkış yapılıyor.");
            break; 
        }
        else
        {
            Console.WriteLine("Geçersiz seçim. Lütfen geçerli bir seçenek giriniz.");
        }
    }
}
