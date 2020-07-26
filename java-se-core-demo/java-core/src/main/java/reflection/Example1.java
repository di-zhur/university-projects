package reflection;

import java.util.ArrayList;
import java.util.List;

public class Example1 {

    public static void main(String[] args) {

        int[][] matrix1 = new int[][] {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9,10,11,12}
        };

        List<Integer> integerList = new ArrayList<>();

        for (int i = 0; i < matrix1.length; i++) {
            int[] matrix2 = matrix1[i];
            for (int j = 0; j < matrix2.length; j++) {
                integerList.add(matrix2[j]);
            }

        }
        integerList.sort(Integer::compareTo);
        integerList.forEach(System.out::println);
    }

    public static void value() {

    }

}
