using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class ChoiceSort
    {
        public T[] Sort<T>(T[] items) where T : IComparable
        {
            int sortedRangeEnd = 0;

            while (sortedRangeEnd < items.Length)
            {
                int nextIndex = FindIndexOfSmallestFromIndex(items, sortedRangeEnd);
                Helper.Swap(items, sortedRangeEnd, nextIndex);

                sortedRangeEnd++;
            }

            return items;
        }

        private int FindIndexOfSmallestFromIndex<T>(T[] items, int sortedRangeEnd) where T : IComparable
        {
            T currentSmallest = items[sortedRangeEnd];
            int currentSmallestIndex = sortedRangeEnd;

            for (int i = sortedRangeEnd + 1; i < items.Length; i++)
            {
                if (currentSmallest.CompareTo(items[i]) > 0)
                {
                    currentSmallest = items[i];
                    currentSmallestIndex = i;
                }
            }

            return currentSmallestIndex;
        }
    }
}
