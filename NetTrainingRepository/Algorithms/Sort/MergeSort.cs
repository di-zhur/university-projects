using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class MergeSort
    {
        public T[] Sort<T>(T[] items) where T : IComparable
        {
            if (items.Length <= 1)
            {
                return null;
            }

            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;
            T[] left = new T[leftSize];
            T[] right = new T[rightSize];
            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);
            Sort(left);
            Sort(right);
            Merge(items, left, right);

            return items;
        }

        private void Merge<T>(T[] items, T[] left, T[] right) where T : IComparable
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int remaining = left.Length + right.Length;
            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else
                {
                    items[targetIndex] = right[rightIndex++];
                }

                targetIndex++;
                remaining--;
            }
        }
    }
}
