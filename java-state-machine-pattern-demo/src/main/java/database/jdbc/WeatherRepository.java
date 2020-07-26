package database.jdbc;

import database.entitys.Weather;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by dmitr on 01.04.2018.
 */
public class WeatherRepository extends DbBase implements Repository<Long, Weather> {

    @Override
    public List<Weather> findAll() {
        List<Weather> weathers = new ArrayList<>();

        try {
            try (Connection connection = getConnection()) {
                Statement statement = connection.createStatement();
                String query = "SELECT * FROM weather.weather";
                ResultSet resultSet = statement.executeQuery(query);
                while (resultSet.next()) {
                    Weather weather = getWeather(resultSet);
                    weathers.add(weather);
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return weathers;
    }

    @Override
    public Weather findById(Long aLong) {
        Weather weather = null;

        try {
            try (Connection connection = getConnection()) {
                String query = "SELECT * FROM weather.weather w WHERE w.Id = ?";
                PreparedStatement preparedStatement = connection.prepareStatement(query);
                preparedStatement.setLong(1, aLong);
                ResultSet resultSet = preparedStatement.executeQuery();
                while (resultSet.next()) {
                    weather = getWeather(resultSet);
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return weather;
    }

    @Override
    public boolean insertAll(List<Weather> entitys) {
        return false;
    }

    @Override
    public boolean insert(Weather entity) {
        return false;
    }

    @Override
    public boolean update(Weather entity) {
        return false;
    }

    @Override
    public void remove(Long aLong) {

    }

    @Override
    public void removeAll() {
        try {
            try (Connection connection = getConnection()) {
                Statement statement = connection.createStatement();
                String query = "DELETE FROM wheather.wheather";
                statement.executeUpdate(query);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    private Weather getWeather(ResultSet resultSet) throws SQLException {
        Weather weather = new Weather();
        weather.setId(resultSet.getLong("id"));
        weather.setDt(resultSet.getDate("dt"));
        weather.setDescription(resultSet.getString("description"));
        weather.setTemperature(resultSet.getDouble("temperature"));
        weather.setPressure(resultSet.getInt("pressure"));
        weather.setHumidity(resultSet.getInt("humidity"));
        weather.setTempmin(resultSet.getDouble("tempmin"));
        weather.setTempmax(resultSet.getDouble("tempmax"));
        weather.setSpeed(resultSet.getDouble("speed"));
        weather.setDeg(resultSet.getInt("deg"));
        weather.setCityid(resultSet.getLong("cityid"));
        return weather;
    }
}
