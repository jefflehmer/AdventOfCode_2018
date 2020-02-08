using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using aoc_2018.Day08;

namespace aoc_2018
{
    public class Day_08
    {
        public static void Do()
        {
            const string InputFile = @"..\..\..\Day_08\data\Day_08_test.aoc";
            //const string InputFile = @"..\..\..\Day_08\data\Day_08_input.aoc";
            var numbers = File
                .ReadAllText(InputFile)
                .Split(" ");
                //.Select(Day_04.ParsedInput.Parse)
                //.OrderBy(x => x.Date)
                //.ToList();

            Do_1(numbers);
            //Do_2(numbers);
        }

        static void Do_1(string[] numbers)
        {
            var tree = new Tree08(numbers);
            Console.WriteLine($"Day 8.1 Metadata Sum: { 8.1 }");
        }

        static void Do_2(string[] numbers)
        {
            Console.WriteLine($"Day86.2: { 8.2 }");
        }
    }
}
