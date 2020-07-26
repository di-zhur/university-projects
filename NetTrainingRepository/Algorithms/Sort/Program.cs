using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Concurrent;
using Sort;

namespace WebFicha
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new int[] { 3, 7, 4, 4, 6, 5, 8 };

            //var bubbleSort = new BubbleSort();
            //var bubbleSortResult = bubbleSort.Sort<int>(data);

            //var choiceSort = new ChoiceSort();
            //var choiceSortResult = choiceSort.Sort(data);

            //var insertionSort = new InsertionSort();
            //var insertionSortResult = insertionSort.Sort(data);

            //var mergeSort = new MergeSort();
            //var mergeSortResult = mergeSort.Sort(data);

            var quickSort = new QuickSort();
            var quickSortResult = quickSort.Sort(data);

            Console.ReadKey();
        }

    }
}
