package science;

public class Science {

    public static void main(String[] args) {
        int[] arr = new int[] { 13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11 };
        heapSort(arr);
        //quickSort(arr, 0, arr.length - 1);
        //mergeSort(arr, 0, arr.length - 1);
        printArr(arr);
    }

    private static void heapSort(int[] arr) {
        int n = arr.length;
        // Построение кучи (перегруппируем массив)
        buildHeap(arr, n);

        //Проходим по построенной куче и меняем местами последний элемент с первым и
        //Перестраиваем кучу на один элемент меньше
        for (int i = n - 1; i >= 0; i--) {
            swap(arr,  0, i);
            buildMaxHeapify(arr, i, 0);
        }
    }

    private static void buildHeap(int[] arr, int n) {
        for (int i = n / 2 - 1; i >= 0; i--) {
            buildMaxHeapify(arr, n, i);
        }
    }

    /**
     *  Max-Heapify
     *
     * @param arr массив
     * @param n размер кучи
     * @param i корень
     */
    private static void buildMaxHeapify(int[] arr, int n, int i) {
        int largest = i;
        int l = 2*i + 1;
        int r = 2*i + 2;

        // Проверка что не ушли за пределы кучи
        // Если левый больше корня, то largest левый
        if (l < n && arr[l] > arr[largest]) {
            largest = l;
        }

        // Проверка что не ушли за пределы кучи
        // Если правый больше корня, то largest правый
        if (r < n && arr[r] > arr[largest]) {
            largest = r;
        }

        // Если самый большой элемент не равно корневому, то меняем местами
        // и повторяем рекурсивно
        if (largest != i) {
            swap(arr, i, largest);

        // Вызываем процедуру heapify на уменьшенной куче
            buildMaxHeapify(arr, n, largest);
        }
    }


    private static void quickSort(int[] arr, int p, int r) {
        if (p < r) {
            int q = partition(arr, p, r);
            quickSort(arr, p, q - 1);
            quickSort(arr, q + 1, r);
        }
    }

    private static int partition(int[] arr, int p, int r) {
        int pivot = arr[r];
        int i = p - 1;
        for (int j = p; j < r; j++) {
            if (arr[j] <= pivot) {
                i = i + 1;
                swap(arr, i, j); // сваливаем в одну сторону что будет до pivot
            }
        }
        swap(arr, i + 1, r); // чтобы pivot встал на нужное место
        return i + 1;
    }

    private static void mergeSort(int[] arr, int l, int r) {
        if (l < r) {
            int m = (l + r) / 2;
            mergeSort(arr, l, m);
            mergeSort(arr, m + 1, r);
            merge(arr, l, m, r);
        }
    }

    private static void merge(int[] arr, int l, int m, int r) {
        int n1 = m - l + 1;
        int n2 = r - m;
        int[] arrL = new int[n1];
        int[] arrR = new int[n2];

        for (int i = 0; i < n1; ++i) {
            arrL[i] = arr[l + i];
        }

        for (int j = 0; j < n2; ++j) {
            arrR[j] = arr[m + 1 + j];
        }

        int i = 0, j = 0, k = l;
        while (i < n1 && j < n2)  {
            if (arrL[i] <= arrR[j]) {
                arr[k] = arrL[i];
                i++;
            } else {
                arr[k] = arrR[j];
                j++;
            }
            k++;
        }

        while (i < n1) {
            arr[k] = arrL[i];
            i++;
            k++;
        }

        while (j < n2) {
            arr[k] = arrR[j];
            j++;
            k++;
        }
    }

    private static int[] insertSort(int[] arr) {
        int length = arr.length;
        for (int i = 1; i < length; i++) {
            int j = i - 1;
            while (j >= 0 && arr[j] > arr[j + 1]) {
                swap(arr, j, j + 1);
                j--;
            }
        }

        return arr;
    }

    private static void swap(int[] arr, int index1, int index2) {
        int temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }

    private static void printArr(int[] arr) {
        for (int i = 0; i < arr.length; i++) {
            System.out.println(arr[i]);
        }
    }
}
