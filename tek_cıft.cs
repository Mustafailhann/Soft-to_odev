çift tek
int sayi;
int cifttoplam = 0;
int tektoplam = 0;
int tek = 0;
int i = 0;
int j = 1;

Console.WriteLine("Lütfen bir sayı girin:");
sayi = Convert.ToInt32(Console.ReadLine());

while (i <= sayi || j <= sayi)
{
    if (i <= sayi)
        cifttoplam += i;

    if (j <= sayi)
        tektoplam += j;

    i += 2;
    j += 2;
}

tek = tektoplam - j;

Console.WriteLine("Çift Sayıların toplamı: " + cifttoplam);
Console.WriteLine("Tek Sayıların toplamı: " + tektoplam);
