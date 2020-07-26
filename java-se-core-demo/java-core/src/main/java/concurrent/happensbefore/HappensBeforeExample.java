package concurrent.happensbefore;

import java.util.concurrent.TimeUnit;

public class HappensBeforeExample {
    static int x = 0, y = 0;
    static int a = 0, b = 0;
    public static void main(String[] args) throws InterruptedException {
        new Thread(new Runnable() {
            public void run() {
                a = 1;
                x = b;
            }
        }).start();
        new Thread(new Runnable() {
            public void run() {
                y = a;
                b = 1;
            }
        }).start();

        Thread.sleep(1000);
        System.out.println("( "+ x + "," + y + ")" + a + " " + b);
    }
}
