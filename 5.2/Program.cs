using System.Text.RegularExpressions;

namespace Hello
{
    class Program
    {
        public static string SumDigits(string userInput)
        {
            int sum = 0;

            if (userInput[0] == '-')
            {
                for (int i = 1; i < userInput.Length; i++)
                {
                    sum += userInput[i];
                }
            }
            else
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    sum += userInput[i] - 48;
                }
            }

            return sum.ToString();
        }

        public static void Main()
        {
            var userInput = Console.ReadLine();
            string pattern = @"^(-|\d)(\d*)$";

            if (Regex.IsMatch(userInput, pattern))
                Console.Write(SumDigits(userInput));
            else
                Console.WriteLine("Неверный формат числа.");
        }
    }
}