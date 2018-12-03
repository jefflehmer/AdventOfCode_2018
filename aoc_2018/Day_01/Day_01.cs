using System;
using System.Collections.Generic;
using System.Text;

namespace aoc_2018
{
    public class Day_01
    {
        public static void Do()
        {
            //const string InputFile = @"C:\GitHub\AdventOfCode_2018\aoc_2018\Day_01\data\Day_01_test_5.aoc";
            const string InputFile = @"C:\GitHub\AdventOfCode_2018\aoc_2018\Day_01\data\Day_01_input.aoc";

            Do_1(InputFile);
            Do_2(InputFile);

            Console.ReadLine();
        }

        static void Do_1(string srcFile)
        {
            var delta = 0;

            var changes = System.IO.File.ReadAllLines(srcFile);
            foreach (var change in changes)
                delta += int.Parse(change);

            Console.WriteLine($"Day 1.1: Resulting Delta: { delta }");
        }

        static void Do_2(string srcFile)
        {
            var frequency = 0;
            //var frequencies = new Dictionary<int, int>();
            var frequencies = new HashSet<int>();
            frequencies.Add(frequency);


            var rawChanges = System.IO.File.ReadAllLines(srcFile);
            var deltas = new Deltas(rawChanges);

            do
            {
                frequency += deltas.Current;
                if (frequencies.Contains(frequency))
                {
                    Console.WriteLine($"Day 1.2: First Repeated Frequency: { frequency }");
                    break;
                }
                frequencies.Add(frequency);
            } while (deltas.MoveNext());
        }
    }
}
