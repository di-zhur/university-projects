using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class QuickSort
    {
        Random _pivotRng = new Random();

        public T[] Sort<T>(T[] items) where T : IComparable
        {
            quicksort(items, 0, items.Length - 1);

            return items;
        }

        private void quicksort<T>(T[] items, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int pivotIndex = _pivotRng.Next(left, right);
                int newPivot = partition(items, left, right, pivotIndex);

                quicksort(items, left, newPivot - 1);
                quicksort(items, newPivot + 1, right);
            }
        }

        private int partition<T>(T[] items, int left, int right, int pivotIndex) where T : IComparable
        {
            T pivotValue = items[pivotIndex];

            Helper.Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (items[i].CompareTo(pivotValue) < 0)
                {
                    Helper.Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            Helper.Swap(items, storeIndex, right);
            return storeIndex;
        }
    }
}
