int sayi;
sayi = int.Parse(Console.ReadLine());

int i = 1;

while (i <= sayi)
{
    int j = sayi;
    while (j >= i)
    {
        Console.Write(i);
        j--;
    }
    i++;
}
Console.ReadLine();
