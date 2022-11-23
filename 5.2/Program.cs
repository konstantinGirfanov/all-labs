using System;

namespace Hello
{
    class Program
    {
        public static bool IsCorrectInput(string userInput)
        {
            if (userInput.Length > 0 && (userInput[0] == '-' || char.IsDigit(userInput[0])))
            {
                for (int i = 1; i < userInput.Length; i++)
                {
                    if (char.IsDigit(userInput[i]))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static string SumDigits(string userInput)
        {
            int number = Math.Abs(int.Parse(userInput));
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
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