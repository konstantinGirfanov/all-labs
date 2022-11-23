using System;

namespace HelloWorld
{
    class Programm
    {
        public static double Factorial(double num)
        {
            double factorial = 1;
            if (num == 0)
                factorial = 1;
            else
            {
                for (int i = 1; i <= num; i++)
                    factorial *= i;
            }

            return factorial;
        }

        public static void WriteDifferenceArray(double[] firstArr, double[] secondArr)
        {
            Console.Write("Начальный массив: ");
            foreach (var x in firstArr)
                Console.Write(x.ToString() + " ");

            Console.WriteLine();

            Console.Write("Конечный массив: ");
            foreach (var x in secondArr)
                Console.Write(x.ToString() + " ");
        }

        public static void Main()
        {
            Console.Write("Размер массива: ");
            var arrSize = int.Parse(Console.ReadLine());

            double[] firstArray = new double[arrSize];
            double[] changedArray = new double[arrSize];

            for (int i = 0; i < arrSize; i++)
            {
                Console.Write("Элемент массива номер " + i.ToString() + ": ");
                firstArray[i] = double.Parse(Console.ReadLine());
            }

            for (int i = 0; i < arrSize; i++)
            {
                if (firstArray[i] > 0 && firstArray[i] % 1 == 0)
                {
                    changedArray[i] = Factorial(firstArray[i]);
                }
                else if (firstArray[i] % 1 != 0)
                {
                    changedArray[i] = Math.Round(firstArray[i] % 1, 2);
                }
                else if (changedArray[i] <= 0)
                {
                    changedArray[i] = firstArray[i];
                }
            }
            WriteDifferenceArray(firstArray, changedArray);
        }
    }
}