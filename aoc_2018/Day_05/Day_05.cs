using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc_2018
{
    public class Day_05
    {
        public static void Do()
        {
            //const string InputFile = @"..\..\..\Day_05\data\Day_05_test.aoc";
            const string InputFile = @"..\..\..\Day_05\data\Day_05_input.aoc";

            Do_1(InputFile);
            Do_2(InputFile);
        }

        static void Do_1(string srcFile)
        {
            var polymer = System.IO.File.ReadAllText(srcFile);
            Console.WriteLine($"Day 5.1: { Reduce(polymer) }");
        }

        static void Do_2(string srcFile)
        {
            var polymer = System.IO.File.ReadAllText(srcFile);
            Console.WriteLine($"Day 5.2: { (from c in "abcdefghijklmnopqrstuvwxyz" select Reduce(polymer, c)).Min() }");
        }

        static int Reduce(string polymer, char? charToSkip = null)
        {
            var stack = new Stack<char>(" "); // can't have empty stack

            foreach (var mer in polymer)
            {
                var top = stack.Peek();
                if (char.ToLower(mer) == charToSkip) continue;
                if (top != mer && char.ToLower(mer) == char.ToLower(top))
                    stack.Pop();
                else
                    stack.Push(mer);
            }
            return stack.Count - 1; // compensate for empty space used to initialize the stack
        }
    }

    public static class Extensions
    {
        public static char ToLower(this char charBuilder, char c)
        {
            return c <= 'Z' ? (char) (c - 'A' + 'a') : c;
        }
    }
}
