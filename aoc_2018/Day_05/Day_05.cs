using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
            var lines = System.IO.File.ReadAllLines(srcFile);

            Console.WriteLine($"Day 5.1: { 0 }");
        }

        static void Do_2(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);

            Console.WriteLine($"Day 5.2: { 0 }");
        }
    }
}
