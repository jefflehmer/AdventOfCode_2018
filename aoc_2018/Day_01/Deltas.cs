using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace aoc_2018.Day_01
{
    public class Deltas : List<int>, IEnumerator<int>
    {
        int _index;

        public Deltas() { }
        public Deltas(string[] rawChanges)
        {
            foreach (var rawChange in rawChanges)
                this.Add(Convert(rawChange));
        }

        public int Convert(string rawChange)
        {
            var value = int.Parse(rawChange.Substring(1, rawChange.Length - 1));
            return rawChange[0] == '-' ? -value : value;
        }

        #region IEnumerator<int>

        public int Current => this[_index];
        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool MoveNext()
        {
            if (_index + 1 == this.Count)
                _index = 0;
            else
                _index++;

            return true;
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Dispose()
        {
            ;
        }
        
        #endregion IEnumerator<int>
    }
}
