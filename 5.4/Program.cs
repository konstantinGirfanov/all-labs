using System;
using System.Numerics;

namespace HelloWorld
{
    class Programm
    {
        public static int Factorial(int number)
        {
            int factorial = 1;
            for (int i = 1; i <= number; i++)
                factorial *= i;

            return factorial;
        }

        public static int ProcessInt(int number)
        {
            if (number >= 0)
                return Factorial(number);
            else
                return number;
        }

        public static double ProcessDouble(double number)
        {
            string fract = Math.Abs(Math.Round(number % 1, 2)).ToString();

            if (fract[2] == 0)
                return double.Parse(fract[3..]);
            else
                return double.Parse(fract[2..]);
        }

        public static void WriteDifferentArrays(double[] firstArr, double[] secondArr)
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
                Console.Write("Элемент массива номер " + i + ": ");
                firstArray[i] = double.Parse(Console.ReadLine());
            }

            for (int i = 0; i < arrSize; i++)
            {
                if (int.TryParse(firstArray[i].ToString(), out _))
                {
                    changedArray[i] = ProcessInt((int)firstArray[i]);
                }
                else
                {
                    changedArray[i] = ProcessDouble(firstArray[i]);
                }
            }

            WriteDifferentArrays(firstArray, changedArray);
        }
    }
}