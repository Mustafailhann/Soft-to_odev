Console.Write("Bir sayı girin: ");
int n = int.Parse(Console.ReadLine());

Console.WriteLine("Asal sayılar:");

int i = 2; 
while (i <= n)
{
    int j = 2;
    bool asal = true;

    while (j < i)
    {
        if (i % j == 0)
        {
            asal = false;
            break; 
        }
        j++;
    }

    if (asal)
    {
        Console.Write(i + " ");
    }

    i++;
}
