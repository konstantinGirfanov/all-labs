using System;

namespace Hello
{
    class Program
    {
        public static void Main()
        {
            float number = float.NaN;

            while (true)
            {
                Console.Write("Введите число: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int resultInt))
                {
                    Console.WriteLine((char)int.Parse(userInput));
                    number = resultInt;
                }

                else if (userInput == "q")
                {
                    break;
                }

                else if(float.TryParse(userInput, out float resultFloat))
                {
                    if (Math.Abs(resultFloat - number) < 1e-9)
                    {
                        break;
                    }
                    else
                    {
                        number = float.Parse(userInput);
                    }
                }
            }
        }
    }
}