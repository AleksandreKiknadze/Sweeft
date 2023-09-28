using System;

namespace Number_Of_Variation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Pleas enter number of stairs: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int NumberOfStairs);

            if (isValid)
            {
                Console.Write("Number of version: ");

                Console.WriteLine(CountVariants(NumberOfStairs));
            }
            else
            {
                Console.WriteLine("Incorrect data, please enter positive whole number");
            }
        }

        static int CountVariants(int stairCounter)
        {
            if (stairCounter <= 0)
            {
                return 0;
            }
            else if (stairCounter == 1)
            {
                return 1;
            }

            int[] array = new int[stairCounter];

            array[0] = 1;
            array[1] = 2;

            for (int i = 2; i < stairCounter; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
            }

            return array[stairCounter - 1];
        }
    }
}