package string;

import java.io.IOException;

public class ClassB extends ClassA {

    static String x = "1";

    public static Object m(String s) {
        System.out.println("b_m" + s);
        return s;
    }

    public void m2() throws RuntimeException, IOException {
        throw new IOException();
    }


}
