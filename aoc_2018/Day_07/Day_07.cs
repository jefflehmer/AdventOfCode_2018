using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace aoc_2018
{
    public class Day_07
    {
        public static void Do()
        {
            //const string InputFile = @"..\..\..\Day_07\data\Day_07_test.aoc";
            const string InputFile = @"..\..\..\Day_07\data\Day_07_input.aoc";
            var lines = System.IO.File.ReadAllLines(InputFile);

            Console.WriteLine($"Day 7.1: { Part1(lines) }");
            Console.WriteLine($"Day 7.2: { Part2(lines) }");
        }
        private static string Part1(string[] input)
        {
            var requirements = new List<Requirement>();
            var steps = new HashSet<char>();
            foreach (var l in input)
            {
                var step = l[36];
                var req = l[5];
                requirements.Add(new Requirement
                {
                    Step = step,
                    Requires = req,
                });

                steps.Add(step);
                steps.Add(req);
            }

            var sorted = steps.ToList();
            sorted.Sort();
            var sb = new StringBuilder();
            while (sorted.Count > 0)
            {
                var ready = sorted.Find((char s) => !requirements.Any((Requirement r) => r.Step == s));
                sb.Append(ready);
                sorted.Remove(ready);
                requirements.RemoveAll((Requirement r) => r.Requires == ready);
            }

            return sb.ToString();
        }

        private static int Part2(string[] input)
        {
            var requirements = new List<(char step, char requires)>();
            var steps = new HashSet<char>();
            foreach (var l in input)
            {
                var step = l[36];
                var req = l[5];
                requirements.Add((step, req));

                steps.Add(step);
                steps.Add(req);
            }

            var sorted = steps.ToList();
            sorted.Sort();
            var time = 0;
            var tasks = new int[5];
            var finished = new Dictionary<char, int>();
            while (sorted.Count > 0 || tasks.Any((int t) => t > time))
            {
                var ready = sorted.FindAll((char s) => !requirements.Any(r => r.step == s));
                for (var t = 0; t < tasks.Length && ready.Count > 0; t++)
                {
                    if (tasks[t] <= time)
                    {
                        tasks[t] = (ready[0] - 'A' + 1) + 60 + time;
                        finished[ready[0]] = tasks[t];
                        sorted.Remove(ready[0]);
                        ready.RemoveAt(0);
                    }
                }

                time++;

                foreach (var k in finished.Keys.ToArray())
                {
                    if (finished[k] <= time)
                    {
                        requirements.RemoveAll(r => r.requires == k);
                        finished.Remove(k);
                    }
                }
            }

            return time;
        }

        private struct Requirement
        {
            public char Step;
            public char Requires;
        }
    }
}
