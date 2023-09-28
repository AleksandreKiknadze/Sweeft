using System;

namespace Min_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 1 };

            Console.WriteLine(NotContains(array));
        }

        static int NotContains(int[] array)
        {
            Array.Sort(array);

            int minNumber = 1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > minNumber)
                {
                    return minNumber;
                }

                if (array[i] == minNumber)
                {
                    minNumber++;
                }
            }

            return minNumber;
        }
    }
}