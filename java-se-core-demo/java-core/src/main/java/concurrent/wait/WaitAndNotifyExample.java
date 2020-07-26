package concurrent.wait;

public class WaitAndNotifyExample {
    private static final Object monitor = new Object();
    private static String message = null;

    public static void main(String[] args) {
        for (int i = 0; i < 5; i++) {
            new Thread(new OperationA()).start();
        }

        new Thread(new OperationB()).start();
    }

    private static class OperationA implements Runnable {

        @Override
        public synchronized void run() {
            String name = Thread.currentThread().getName();
            try {
                synchronized (monitor) {
                    System.out.println(name + "operation time:" + System.currentTimeMillis());
                    monitor.wait();
                }
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            System.out.println(message + "message:" + System.currentTimeMillis());
        }
    }

    private static class OperationB implements Runnable {

        @Override
        public void run() {
            String name = Thread.currentThread().getName();
            System.out.println(name + "OperationB time:" + System.currentTimeMillis());
            try {
                Thread.sleep(2000);
                synchronized (monitor) {
                    message = "message" + System.currentTimeMillis();
                    monitor.notifyAll();
                }
                Thread.sleep(10000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

}
