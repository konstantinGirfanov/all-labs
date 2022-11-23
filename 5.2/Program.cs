using System;

namespace Hello
{
    class Program
    {
        public static bool IsCorrectInput(string userInput)
        {
            int countMinus = 0;
            int countComma = 0;

            while (true)
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    if ((char.IsDigit(userInput[i]) || userInput[i] == '-'))
                    {
                        if (userInput[i] == '-')
                        {
                            countMinus++;
                            if (countMinus == 2)
                                return false;
                        }
                        continue;
                    }
                    else
                        return false;
                }

                return true;
            }
        }

        public static string SumDigits(string a)
        {
            var b = Math.Abs(int.Parse(a));
            int sum = 0;

            while (b > 0)
            {
                sum += b % 10;
                b /= 10;
            }

            return sum.ToString();
        }

        public static void Main()
        {
            var userInput = Console.ReadLine();

            if (IsCorrectInput(userInput))
            {
                Console.Write(SumDigits(userInput));
            }
            else Console.WriteLine("Неверный формат числа.");
        }
    }
}