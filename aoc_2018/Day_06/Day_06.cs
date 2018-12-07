using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc_2018
{
    public class Day_06
    {
        public static void Do()
        {
            //const string InputFile = @"..\..\..\Day_06\data\Day_06_test.aoc";
            const string InputFile = @"..\..\..\Day_06\data\Day_06_input.aoc";

            Do_1(InputFile);
            Do_2(InputFile);
        }

        static void Do_1(string srcFile)
        {
            var coords = GetCoords(srcFile);

            var minX = MinX(coords);
            var maxX = MaxX(coords);
            var minY = MinY(coords);
            var maxY = MaxY(coords);

            var area = new int[coords.Length];

            foreach (var x in Enumerable.Range(minX, maxX - minX + 1))
            {
                foreach (var y in Enumerable.Range(minY, maxY - minX + 1))
                {
                    var d = coords.Select(coord => ManhattanDistance((x, y), coord)).Min();
                    var closest = Enumerable.Range(0, coords.Length).Where(i => ManhattanDistance((x, y), coords[i]) == d).ToArray();

                    if (closest.Length != 1)
                    {
                        continue;
                    }

                    if (x == minX || x == maxX || y == minY || y == maxY)
                    {
                        foreach (var icoord in closest)
                        {
                            if (area[icoord] != -1)
                            {
                                area[icoord] = -1;
                            }
                        }
                    }
                    else
                    {
                        foreach (var icoord in closest)
                        {
                            if (area[icoord] != -1)
                            {
                                area[icoord]++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Day 6.1: { area.Max() }");
        }

        static void Do_2(string srcFile)
        {
            var coords = GetCoords(srcFile);

            var minX = MinX(coords);
            var maxX = MaxX(coords);
            var minY = MinY(coords);
            var maxY = MaxY(coords);

            var area = 0;

            foreach (var x in Enumerable.Range(minX, maxX - minX + 1))
            {
                foreach (var y in Enumerable.Range(minY, maxY - minX + 1))
                {
                    var d = coords.Select(coord => ManhattanDistance((x, y), coord)).Sum();
                    if (d < 10000)
                        area++;
                }
            }
            Console.WriteLine($"Day 6.2: { area }");
        }

        static int ManhattanDistance((int x, int y) c1, (int x, int y) c2)
        {
            return Math.Abs(c1.x - c2.x) + Math.Abs(c1.y - c2.y);
        }

        // by reading in all lines as a single text we are able to traverse the entries in a linq statement using .Split("\n") which also parses each line then converts all ints from strings
        static (int x, int y)[] GetCoords(string srcFile) {
            var lines = System.IO.File.ReadAllText(srcFile);
            return ParseCoords(lines);
        }
        static (int x, int y)[] ParseCoords(string input) => (
                from line in input.Split("\n")
                let coords = line.Split(", ").Select(int.Parse).ToArray()
                select (coords[0], coords[1])
            ).ToArray();

        static int MinX((int x, int y)[] coords) => coords.Min(coord => coord.x) - 1;
        static int MaxX((int x, int y)[] coords) => coords.Max(coord => coord.x) + 1;
        static int MinY((int x, int y)[] coords) => coords.Min(coord => coord.y) - 1;
        static int MaxY((int x, int y)[] coords) => coords.Max(coord => coord.y) + 1;
    }
}
