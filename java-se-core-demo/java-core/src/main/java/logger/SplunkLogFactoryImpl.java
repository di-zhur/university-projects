package logger;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class SplunkLogFactoryImpl {

    private final SettingsService settingsService;

    public SplunkLogFactoryImpl(SettingsService settingsService) {
        this.settingsService = settingsService;
    }

    public SplunkLog getLog(Class<?> clazz) {
        Logger logger = LoggerFactory.getLogger(clazz);
        return new SplunkLogImpl(settingsService, logger);
    }

}
