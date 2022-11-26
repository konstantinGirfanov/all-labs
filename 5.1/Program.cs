using System;

namespace Hello
{
    class Program
    {
        public static void Main()
        {
            bool isFirstInput = true;
            float previousNum = 0f;
            float currentNum = 0f;

            while (true)
            {
                Console.Write("Введите число: ");
                var userInput = Console.ReadLine();

                if (isFirstInput)
                {
                    isFirstInput = false;
                    float.TryParse(userInput, out currentNum);
                    previousNum = currentNum - 1;
                }
                else
                {
                    if(float.TryParse(userInput, out _))
                    {
                        previousNum = currentNum;
                        currentNum = float.Parse(userInput);
                    }
                }

                if (int.TryParse(userInput, out int b))
                {
                    Console.WriteLine(b.ToString());
                }
                
                if (!int.TryParse(userInput, out _) || userInput == "q")
                {
                    if (Math.Abs(previousNum - currentNum) < 1e-9 || userInput == "q")
                    {
                        break;
                    }
                }
            }
        }
    }
}