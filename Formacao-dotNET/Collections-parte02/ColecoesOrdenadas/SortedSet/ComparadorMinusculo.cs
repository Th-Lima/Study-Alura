using System;
using System.Collections.Generic;

namespace SortedSet
{
    public class ComparadorMinusculo : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
