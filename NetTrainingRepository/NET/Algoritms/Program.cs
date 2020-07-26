using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static IList<int> arr = new List<int>() { 2, 1, 3, 4, 5 }.ToArray();
        private static bool[] used = new bool[arr.Count];
        private static int newPos;

        public static void PancakeSort()
        {

            for (int i = arr.Count - 1; i >= 0; --i)
            {
                int pos = i;

                pos = FindDepth(pos);

                if (pos != i) continue;

                Flip(arr, pos + 1);
            }
        }

        private static IList<int> Flip(IList<int> arr, int n)
        {
            var newList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                --n;
                int tmp = arr[i];
                arr[i] = arr[n];
                arr[n] = tmp;
            }

            Console.WriteLine("------");
            foreach (var value in arr)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("------");

            return arr;
        }

        private static int FindDepth(int pos, int? maxPos = null)
        {
            used[pos] = true;

            for (int next = 0; next < arr.Count; next++)
            {
                if (!used[next])
                {
                    var max = maxPos ?? pos;
                    newPos = arr[max] > arr[next] ? max : next;

                    if (next == 0) continue;

                    FindDepth(next, newPos);
                }
            }


            return newPos;
        }
    }
}
