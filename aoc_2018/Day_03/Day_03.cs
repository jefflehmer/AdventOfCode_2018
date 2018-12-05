using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc_2018
{
    public class Day_03
    {
        public static void Do()
        {
            //const string InputFile = @"..\..\..\Day_03\data\Day_03_test.aoc";
            const string InputFile = @"..\..\..\Day_03\data\Day_03_input.aoc";

            Do_1(InputFile);
            Do_2(InputFile);

            //Console.WriteLine($"Number of Square Inches: { (InputFile) }");
        }

        static void Do_1(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);

            var coords = new HashSet<string>();
            var overlap = new HashSet<string>();
            foreach (var l in lines)
            {
                var parts = l.Split(new string[] { " @ ", ",", ": ", "x" }, StringSplitOptions.RemoveEmptyEntries);
                var left = int.Parse(parts[1]);
                var top = int.Parse(parts[2]);
                var width = int.Parse(parts[3]);
                var height = int.Parse(parts[4]);
                for (var x = left; x < width + left; x++)
                {
                    for (var y = top; y < height + top; y++)
                    {
                        if (!coords.Add($"{x}x{y}"))
                        {
                            overlap.Add($"{x}x{y}");
                        }
                    }
                }
            }

            Console.WriteLine($"Day 3.1: { overlap.Count }");
        }

        static void Do_2(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);

            var ids = new HashSet<int>();
            foreach (var l in lines)
            {
                ids.Add(int.Parse(l.Substring(1, l.IndexOf(' '))));
            }

            var map = new Dictionary<string, List<int>>();
            foreach (var l in lines)
            {
                var parts = l.Split(new string[] { " @ ", ",", ": ", "x" }, StringSplitOptions.RemoveEmptyEntries);
                var left = int.Parse(parts[1]);
                var top = int.Parse(parts[2]);
                var width = int.Parse(parts[3]);
                var height = int.Parse(parts[4]);
                for (var x = left; x < width + left; x++)
                {
                    for (var y = top; y < height + top; y++)
                    {
                        List<int> list;
                        if (!map.TryGetValue($"{x}x{y}", out list))
                        {
                            list = new List<int>();
                        }

                        list.Add(int.Parse(parts[0].Substring(1)));
                        map[$"{x}x{y}"] = list;
                    }
                }
            }

            foreach (var pos in map.Values)
            {
                if (pos.Count > 1)
                {
                    ids.RemoveWhere((int i) => pos.Contains(i));
                }
            }

            Console.WriteLine($"Day 3.2: { new List<int>(ids)[0] }");
        }
    }
}
