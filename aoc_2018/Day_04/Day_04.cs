using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc_2018
{
    public class Day_04
    {
        public static void Do()
        {
            //const string InputFile = @"..\..\..\Day_04\data\Day_04_test.aoc";
            const string InputFile = @"..\..\..\Day_04\data\Day_04_input.aoc";

            KeyValuePair<int, int> Def = new KeyValuePair<int, int>(0, 0);

            var lines = File
                .ReadAllText(InputFile)
                .Split(Environment.NewLine)
                .Select(ParsedInput.Parse)
                .OrderBy(x => x.Date)
                .ToList();

            var allSchedules = lines
                .Select((x, i) =>
                {
                    if (x.Id == null)
                        x.Id = lines[i - 1].Id;

                    return x;
                })
                .GroupBy(x => x.Id.Value)
                .Select(x =>
                {
                    var asleep = x.Where(y => y.Action == Action.FallsAsleep);
                    var awake = x.Where(y => y.Action == Action.WakesUp);

                    var schedule = asleep
                        .Zip(awake, (a, w) => Enumerable.Range(a.Date.Minute, w.Date.Minute - a.Date.Minute))
                        .SelectMany(y => y)
                        .GroupBy(y => y)
                        .Select(y => new { Minute = y.Key, Total = y.Count() })
                        .ToDictionary(y => y.Minute, y => y.Total);

                    return new { Id = x.Key, Schedule = schedule };
                });

            var chosen1 = allSchedules.Aggregate((x1, x2) => 
                x1.Schedule.Sum(y => y.Value) > x2.Schedule.Sum(y => y.Value) ? x1 : x2);

            var chosen2 = allSchedules.Aggregate((x1, x2) => 
                x1.Schedule.Max(y => y.Value) > x2.Schedule.DefaultIfEmpty(Def).Max(y => y.Value) ? x1 : x2);

            var result1 = chosen1.Id * chosen1.Schedule.Aggregate((x1, x2) => x1.Value > x2.Value ? x1 : x2).Key;
            var result2 = chosen2.Id * chosen2.Schedule.Aggregate((x1, x2) => x1.Value > x2.Value ? x1 : x2).Key;

            Console.WriteLine($"Day 4.1: { result1 }");
            Console.WriteLine($"Day 4.2: { result2 }");
        }
        public class ParsedInput
        {
            public int? Id { get; set; }
            public DateTime Date { get; set; }
            public Action Action { get; set; }

            public ParsedInput(string input)
            {
                var span = input.AsSpan();
                var text = span.Slice(19).ToString();

                Id = null;
                Date = DateTime.Parse(span.Slice(1, 16));

                if (text == "falls asleep")
                    Action = Action.FallsAsleep;
                else if (text == "wakes up")
                    Action = Action.WakesUp;
                else
                {
                    var index = span.IndexOf("#") + 1;
                    Id = int.Parse(span.Slice(index, span.IndexOf(" begins") - index));
                    Action = Action.BeginsShift;
                }
            }

            public static ParsedInput Parse(string input) => new ParsedInput(input);
        }

        public enum Action
        {
            BeginsShift, FallsAsleep, WakesUp
        }
    }
}
