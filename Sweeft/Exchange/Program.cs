using System;

namespace Exchange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pleas enter amount of money");
            bool isValid = int.TryParse(Console.ReadLine(), out int amount);

            if (isValid)
            {
                Console.WriteLine(MinSplit(amount));
            }
            else
            {
                Console.WriteLine("Incorrect data, please enter positive whole number");
            }
        }

        static int MinSplit(int amount)
        {
            int[] coins = { 50, 20, 10, 5, 1 };

            int totalCount = 0;

            for (int i = 0; i < coins.Length; i++)
            {
                while (amount >= coins[i])
                {
                    int count = amount / coins[i];

                    totalCount += count;

                    amount -= count * coins[i];
                }
            }

            return totalCount;
        }
    }
}