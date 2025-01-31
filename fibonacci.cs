Console.Write("Gösterilecek Fibonacci Adım Sayısını Girin: ");
int sayi = int.Parse(Console.ReadLine());

int a = 1, b = 1;
int i = 0;

while (i < sayi)
{
    Console.Write(a + " ");
    
    int adim = a + b;
    a = b;
    b = adim;
    
    i++;
}
