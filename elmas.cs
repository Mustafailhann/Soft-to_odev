// Elmas Şekli

Console.WriteLine("Orta satırdaki * sayısını girin (tek sayı):");
int n;
while (true)
{
    n = int.Parse(Console.ReadLine());

    if (n % 2 != 0) // Eğer sayı tekse döngüden çık
        break;

    Console.Write("Lütfen TEK bir sayı girin: ");
}

// Üst kısım
int i = 1;
while (i <= n)
{
    int bosluk = (n - i) / 2;
    int yildiz = i;

    int j = 0;
    while (j < bosluk)
    {
        Console.Write(" ");
        j++;
    }

    j = 0;
    while (j < yildiz)
    {
        Console.Write("*");
        j++;
    }

    Console.WriteLine();
    i += 2;
}

// Alt kısım
i = n - 2;
while (i >= 1)
{
    int bosluk = (n - i) / 2;
    int yildiz = i;

    int j = 0;
    while (j < bosluk)
    {
        Console.Write(" ");
        j++;
    }

    j = 0;
    while (j < yildiz)
    {
        Console.Write("*");
        j++;
    }

    Console.WriteLine();
    i -= 2;
}


