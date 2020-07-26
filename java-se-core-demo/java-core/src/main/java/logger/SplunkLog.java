package logger;

public interface SplunkLog {

    SplunkLogger info(String name);

    SplunkLogger error(String name, Throwable t);

}
