package lambda;

import java.util.Comparator;
import java.util.function.*;

public class Example {

    private static Predicate<Integer> b1 = (Integer a) -> a > 5;
    private static Predicate<Integer> b2 = (Integer a) -> a > 6;

    private static Consumer<Integer> b3 = System.out::println;

    private static Supplier<Integer> b4 = () -> 10;

    private static Comparator<Integer> b5 = Integer::compareTo;

    private static Function<Integer, String> b6 = a -> (a++).toString();

    private static UnaryOperator<String> b7 = a -> a + "sdada";
    private static BinaryOperator<String> b8 = (a, b) -> a + b;

    public static void main(String[] args) {
        System.out.println(b1.and(b2).test(10));
        b3.accept(10);
        System.out.println(b4.get());
        System.out.println(b5.compare(1, 1));
        System.out.println(b6.apply(55));
        System.out.println(b7.apply("11 "));
        System.out.println(b8.apply("1", "2"));
    }

}
