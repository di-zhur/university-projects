package logger;

import org.slf4j.Logger;

public abstract class SplunkBaseLogger implements SplunkLogger {

    private final SettingsService settingsService;
    private final Logger logger;

    public SplunkBaseLogger(SettingsService settingsService, Logger logger) {
        this.settingsService = settingsService;
        this.logger = logger;
    }

    protected SettingsService getSettingsService() {
        return settingsService;
    }

    protected Logger getLogger() {
        return logger;
    }

    public SplunkLogger hashId(String merchantId, String pan) {
        return this;
    }

    public SplunkLogger transactionId(String transactionId) {
        return this;
    }

    public SplunkLogger merchantId(String merchantId) {
        return this;
    }

    public SplunkLogger map(String name, Object value) {
        return this;
    }

    public SplunkLogger field(String name, Object value) {
        return this;
    }

    public abstract void log();

}
