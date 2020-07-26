package database.jdbc;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 * Created by dmitr on 02.04.2018.
 */
public class DbBase {

    private final static String URL = "jdbc:postgresql://localhost:5430/delta";
    private final static String USER = "postgres";
    private final static String PASSWORD = "123qweQWE";

    public Connection getConnection() throws SQLException {
        Connection connection = DriverManager.getConnection(URL, USER, PASSWORD);
        return connection;
    }
}
