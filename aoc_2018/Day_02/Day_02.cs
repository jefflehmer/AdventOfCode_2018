using System;
using System.Collections.Generic;
using System.Text;

namespace aoc_2018
{
    public class Day_02
    {
        public static void Do()
        {
            const string InputFile = @"C:\GitHub\AdventOfCode_2018\aoc_2018\Day_02\data\Day_02_test.aoc";
            //const string InputFile = @"C:\GitHub\AdventOfCode_2018\aoc_2018\Day_02\data\Day_02_input.aoc";

            Do_1(InputFile);
            //Do_2(InputFile);

            Console.ReadLine();
        }

        // TODO: this solution is way too complex...think up a simpler one!
        static void Do_1(string srcFile)
        {
            var checksum = 0;
            var duets = new HashSet<string>();
            var tercets = new HashSet<string>();

            var lines = System.IO.File.ReadAllLines(srcFile);
            foreach (var line in lines)
            {
                var scan = new Scan(line);
                var twos = scan.Matches(2).Split();
                foreach (var two in twos)
                {
                    if (!duets.Contains(two))
                        duets.Add(two);
                }
                var tres = scan.Matches(3).Split();
                foreach (var tre in tres)
                {
                    if (!tercets.Contains(tre))
                        tercets.Add(tre);
                }
            }

            Console.WriteLine($"Day 2.1: Checksum: { duets.Count * tercets.Count }");
        }

        static void Do_2(string srcFile)
        {
        }
    }
}
