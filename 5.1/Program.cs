namespace Hello
{
    class Program
    {
        public static void Main()
        {
            float previousNum = -1f;
            float currentNum = 0f;
            bool isFirstInput = true;

            while (true)
            {
                Console.Write("Введите число: ");
                var userInput = Console.ReadLine();

                if (isFirstInput)
                {
                    isFirstInput = false;
                }
                else
                {
                    previousNum = currentNum;
                }
                currentNum = float.Parse(userInput);

                if (int.TryParse(userInput, out int b))
                {
                    Console.WriteLine(b.ToString());
                }

                if (Math.Abs(previousNum - currentNum) < 1e-9 || userInput == "q") break;
            }
        }
    }
}