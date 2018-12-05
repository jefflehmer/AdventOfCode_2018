using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc_2018
{
    public class Day_02
    {
        public static void Do()
        {
            //const string InputFile = @"..\..\..\Day_02\data\Day_02_test.aoc";
            const string InputFile = @"..\..\..\Day_02\data\Day_02_input.aoc";

            //Do_1(InputFile);
            PartTwo(InputFile);
        }

        static void Do_1(string srcFile)
        {
            var duets = 0;
            var tercets = 0;

            var lines = System.IO.File.ReadAllLines(srcFile);
            foreach (var line in lines)
            {
                var letterGroups = line.GroupBy(l => l).Select(g => new { Key = g.Key, Counter = g.Count() });

                if (letterGroups.Any(g => g.Counter == 2))
                    duets++;
                if (letterGroups.Any(g => g.Counter == 3))
                    tercets++;
            }

            Console.WriteLine($"Day 2.1: Checksum: duets({duets}) * tercets({tercets}) + { duets * tercets }");
        }

        static void Do_2(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile).OrderBy(l => l).ToList();
            foreach (var line in lines) Console.WriteLine(line);
            for (int idx = 1; idx < lines.Count(); idx++)
            {
                var line1 = lines[idx - 1];
                var line2 = lines[idx];

                var diff = line1.Zip(line2, (w1, w2) => w1 == w2 ? 0 : 1).Sum();

                if (diff == 1)
                    Console.WriteLine($"Day 2.2: Box ID: { string.Join("", line1.Zip(line2, (w1, w2) => w1 == w2 ? w1.ToString() : "")) }");
            }
            Console.WriteLine("Done outputting values for Day 2.2!");
        }

        static void PartTwo(string input)
        {
            var lines = System.IO.File.ReadAllLines(input).OrderBy(l => l).ToList();
            Console.WriteLine( (from i in Enumerable.Range(0, lines.Count)
                    from j in Enumerable.Range(i + 1, lines.Count - i - 1)
                    let line1 = lines[i]
                    let line2 = lines[j]
                    where Diff(line1, line2) == 1
                    select Common(line1, line2)
            ).Single());
        }

        static int Diff(string line1, string line2)
        {
            return line1.Zip(line2,
                (chA, chB) => chA == chB
            ).Count(x => x == false);
        }

        static string Common(string line1, string line2)
        {
            return string.Join("", line1.Zip(line2, (chA, chB) => chA == chB ? chA.ToString() : ""));
        }
    }
}
