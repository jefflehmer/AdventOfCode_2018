using System;
using System.Collections.Generic;
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

            Do_1(InputFile);
            //Do_2(InputFile);

            Console.ReadLine();
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
        }
    }
}
