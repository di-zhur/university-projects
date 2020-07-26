package logger;

import org.slf4j.Logger;

public class SplunkLogImpl implements SplunkLog {

    private final SettingsService settingsService;
    private final Logger logger;

    public SplunkLogImpl(SettingsService settingsService, Logger logger) {
        this.settingsService = settingsService;
        this.logger = logger;
    }

    @Override
    public SplunkLogger info(String name) {
        return new SplunkInfoLogger(settingsService, logger, name);
    }

    @Override
    public SplunkLogger error(String name, Throwable t) {
        return null;
    }

}
