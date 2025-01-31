int body = int.Parse(Console.ReadLine());
int satir = (body * 2) - 1;

int i = 1;
while (i <= satir)
{
    Console.WriteLine();
    int bosluk = (satir - i) / 2;

    int j = 0;
    while (j < bosluk)
    {
        Console.Write(" ");
        j++;
    }

    j = 0;
    while (j < i)
    {
        Console.Write("*");
        j++;
    }

    i += 2;
}

Console.Write(body);

i = 0;
while (i < ((satir - 1) / 2))
{
    Console.WriteLine();

    int j = 0;
    while (j < ((satir - 3) / 2))
    {
        Console.Write(" ");
        j++;
    }

    int m = 0;
    while (m < 3)
    {
        Console.Write("*");
        m++;
    }

    i++;
}
