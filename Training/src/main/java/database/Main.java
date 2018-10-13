package database;

import database.entitys.Weather;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by dmitr on 01.04.2018.
 */
public class Main {

    public static void main(String[] args) throws SQLException {

        String url = "jdbc:postgresql://localhost:5430/delta";
        String user = "postgres";
        String password = "123qweQWE";
        List<Weather> weathers = new ArrayList<>();

        try (Connection connection = DriverManager.getConnection(url, user, password)) {

            PreparedStatement preparedStatement =
                    connection.prepareStatement("SELECT * FROM weather.weather AS w WHERE w.Id = ?");
            preparedStatement.setLong(1, 26756);
            ResultSet resultSet = preparedStatement.executeQuery();

            while (resultSet.next()) {
                Weather weather = new Weather();
                weather.setId(resultSet.getLong("id"));
                weather.setDt(resultSet.getDate("dt"));
                weather.setSpeed(resultSet.getDouble("speed"));
                weathers.add(weather);
            }
        }

        weathers.forEach(i -> {
            System.out.println(i.getId());
            System.out.println(i.getDt());
            System.out.println(i.getSpeed());
        });
    }

}
