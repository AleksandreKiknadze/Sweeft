using System;

namespace Palidrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Console.WriteLine(IsPalindrome(text));
        }

        static bool IsPalindrome(string text)
        {
            bool palindrome = true;

            int size = text.Length;

            for (int i = 0; i < size / 2; i++)
            {
                if (text[i] != text[size - i - 1])
                {
                    palindrome = false;
                }
            }

            return palindrome;
        }
    }
}