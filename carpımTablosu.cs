
            int i = 1;
            int j;
            while (i <= 10) 
            {
                j = 1;
                while (j <= 10)
                {
                    Console.WriteLine($"{i} * {j} = {i*j}");
                    ++j;
                }
                ++i;
                if (i == 11)
                {
                    break;
                }
                Console.WriteLine("------------------");
            }