using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class InsertionSort
    {
        public T[] Sort<T>(T[] items) where T : IComparable
        {
            int sortedRangeEndIndex = 1;

            while (sortedRangeEndIndex < items.Length)
            {
                if (items[sortedRangeEndIndex].CompareTo(items[sortedRangeEndIndex - 1]) < 0)
                {
                    int insertIndex = FindInsertionIndex(items, items[sortedRangeEndIndex]);
                    Insert(items, insertIndex, sortedRangeEndIndex);
                }

                sortedRangeEndIndex++;
            }

            return items;
        }

        private int FindInsertionIndex<T>(T[] items, T valueToInsert) where T : IComparable
        {
            for (int index = 0; index < items.Length; index++)
            {
                if (items[index].CompareTo(valueToInsert) > 0)
                {
                    return index;
                }
            }

            throw new InvalidOperationException("The insertion index was not found");
        }

        /*
           // itemArray =       0 1 2 4 5 6 3 7
            // insertingAt =     3
            // insertingFrom =   6
            // 
            // Действия:
            //  1: Сохранить текущий индекс в temp
            //  2: Заменить indexInsertingAt на indexInsertingFrom
            //  3: Заменить indexInsertingAt на indexInsertingFrom в позиции +1
            //     Сдвинуть элементы влево на один.
            //  4: Записать temp на позицию в массиве + 1.

             */

        private void Insert<T>(T[] itemArray, int indexInsertingAt, int indexInsertingFrom)
        {
            T temp = itemArray[indexInsertingAt];
            
            itemArray[indexInsertingAt] = itemArray[indexInsertingFrom];
            
            for (int current = indexInsertingFrom; current > indexInsertingAt; current--)
            {
                itemArray[current] = itemArray[current - 1];
            }
            
            itemArray[indexInsertingAt + 1] = temp;
        }
    }
}
