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

                if (int.TryParse(userInput, out _))
                {
                    Console.WriteLine((char)int.Parse(userInput));
                    number = float.Parse(userInput);
                }
                else if (float.TryParse(userInput, out _) || userInput == "q")
                {
                    if (userInput == "q" || Math.Abs(float.Parse(userInput) - number) <  1e-9)
                    {
                        break;
                    }
                    else
                    {
                        number = float.Parse(userInput);
                    }
                }



                /*if (isFirstInput)
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
                }*/
            }
        }
    }
}