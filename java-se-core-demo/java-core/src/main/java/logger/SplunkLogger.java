package logger;

public interface SplunkLogger {

    SplunkLogger hashId(String merchantId, String pan);

    SplunkLogger transactionId(String transactionId);

    SplunkLogger merchantId(String merchantId);

    SplunkLogger map(String name, Object value);

    SplunkLogger field(String name, Object value);

    void log();

}
