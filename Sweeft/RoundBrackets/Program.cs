using System;
using System.Collections.Generic;

namespace Properly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = "(())(())";

            Console.WriteLine(IsProperly(sequence));
        }

        static bool IsProperly(string sequence)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '(')
                {
                    stack.Push(sequence[i]);
                    continue;
                }

                if (sequence[i] == ')' && stack.Peek() == '(')
                {
                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
    }
}