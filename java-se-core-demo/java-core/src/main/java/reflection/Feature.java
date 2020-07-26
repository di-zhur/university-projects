package reflection;

public class Feature {

    public void execute() {
        System.out.println(getClass().getName());
        Thread thread = Thread.currentThread();
        StackTraceElement[] stackTraceElements  = thread.getStackTrace();
        System.out.println(stackTraceElements);

    }

}
