Console.Write("Bir sayı girin: ");
int num = int.Parse(Console.ReadLine());

int i = 1;
while (i <= num)
{
    if (num % i == 0)
    {
        Console.WriteLine(i);
    }
    i++;
}
