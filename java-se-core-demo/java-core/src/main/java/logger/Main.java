package logger;

public class Main {
    private static SplunkLog splunkLog;
    public Main() {
        splunkLog = new SplunkLogFactoryImpl(null).getLog(Main.class);
    }

    public static void main(String[] args) {
        int N_CPUS = Runtime.getRuntime().availableProcessors();
        System.out.println(N_CPUS);
        splunkLog.info("").hashId("", "").field("", "").field("", "").log();
    }

}
