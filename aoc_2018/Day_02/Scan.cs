using System;
using System.Collections.Generic;
using System.Text;

namespace aoc_2018
{
    public class Scan
    {
        string Letters { get; set; }
        Dictionary<char, CharCounter> Counters { get; set; }

        public Scan() { }
        public Scan(string scan)
        {
            Letters = scan;
            CollectCounters();
        }

        // TODO: use LINQ "Group" instead of a dictionary
        void CollectCounters()
        {
            Counters = new Dictionary<char, CharCounter>();
            foreach (var letter in Letters)
            {
                if (Counters.ContainsKey(letter))
                {
                    var counter = Counters[letter];
                    if (counter != null)
                        counter.Count++;
                }
                else
                    Counters[letter] = new CharCounter { Letter = letter, Count = 1 };
            }
        }

        public string Matches(int match)
        {
            var matches = new StringBuilder();
            var count = 0;
            foreach(var kvp in Counters)
            {
                if (kvp.Value.Count == match)
                    matches.Append(kvp.Value.Letter);
            }
            return matches.ToString();
        }

        class CharCounter
        {
            public char Letter { get; set; }
            public int Count { get; set; }
        }
    }
}
