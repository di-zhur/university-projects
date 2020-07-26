package logger;

import org.slf4j.Logger;

public class SplunkInfoLogger extends SplunkBaseLogger {

    public SplunkInfoLogger(SettingsService settingsService, Logger logger, String name) {
        super(settingsService, logger);
    }

    @Override
    public void log() {
        if (getSettingsService().get() != null) {
            getLogger().info("1");
        } else {
            getLogger().info("eventName not");
        }
    }
}
