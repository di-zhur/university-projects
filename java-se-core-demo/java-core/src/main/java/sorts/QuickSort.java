package sorts;

import java.util.Comparator;
import java.util.Random;

public class QuickSort {

    private static final Random RND = new Random();

    public static void main(String[] args) {
        Integer[] array = new Integer[] {40, 90, 60, 5, 13, 10, 20, 45, 50};
        printArray(array);
        sort(array, Comparator.naturalOrder());
        printArray(array);
    }

    private static void sort(Object[] array, Comparator cmp) {
        qsort(array, 0, array.length - 1, cmp);
    }

    private static void swap(Object[] array, int i, int j) {
        Object tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }

    private static int partition(Object[] array, int begin, int end, Comparator cmp) {
        int index = begin;
        Object pivot = array[index];
        swap(array, index, end);
        printArray(array);
        for (int i = index = begin; i < end; ++ i) {
            if (cmp.compare(array[i], pivot) <= 0) {
                swap(array, index++, i);
                printArray(array);
            }
        }
        swap(array, index, end);
        printArray(array);
        return index;
    }

    private static void qsort(Object[] array, int begin, int end, Comparator cmp) {
        if (end > begin) {
            int index = partition(array, begin, end, cmp);
            printArray(array);
            qsort(array, begin, index - 1, cmp);
            printArray(array);
            qsort(array, index + 1,  end,  cmp);
            printArray(array);
        }
    }

    private static void printArray(Object[] array) {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < array.length; i++) {
             stringBuilder.append(array[i] + " ");
        }
        System.out.println(stringBuilder.toString());
    }
}
