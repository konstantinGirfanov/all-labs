using System;

namespace Hello
{
    class Program
    {
        public static void Main()
        {
            float[] numbers = new float[2];
            while (true)
            {
                Console.Write("Введите число: ");
                var a = Console.ReadLine();

                if (int.TryParse(a, out int b))
                {
                    Console.WriteLine(b.ToString());
                    continue;
                }

                else
                {
                    if (numbers[0] == 0)
                        float.TryParse(a, out numbers[0]);
                    else if (numbers[0] != 0 && numbers[1] == 0)
                        float.TryParse(a, out numbers[1]);
                    else if (numbers[0] != 0 && numbers[1] != 0 && float.TryParse(a, out _))
                    {
                        numbers[0] = numbers[1];
                        float.TryParse(a, out numbers[1]);
                    }
                }

                if (numbers[0] == numbers[1] || a == "q") break;
            }
        }
    }
}