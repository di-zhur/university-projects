using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class BubbleSort
    {
        public T[] Sort<T>(T[] items) where T : IComparable
        {
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i - 1].CompareTo(items[i]) > 0)
                    {
                        Helper.Swap(items, i - 1, i);
                        swapped = true;
                    }
                }
            } while (swapped != false);

            return items;
        }
    }
}
