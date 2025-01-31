Console.WriteLine("Bir sayı giriniz:");

int sayi = 1;
int toplam = 0;
int i = 0;

while (sayi % 4 != 0) 
{
    i++;
    Console.Write(i + ". sayıyı giriniz: ");
    sayi = int.Parse(Console.ReadLine());
    toplam += sayi;
}

Console.WriteLine("Toplam: " + toplam);
