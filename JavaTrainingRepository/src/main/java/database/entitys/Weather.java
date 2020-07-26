package database.entitys;

import java.sql.Date;
import java.util.Objects;

/**
 * Created by dmitr on 01.04.2018.
 */
public class Weather {
    private long id;
    private Date dt;
    private String description;
    private Double temperature;
    private Integer pressure;
    private Integer humidity;
    private Double tempmin;
    private Double tempmax;
    private Double speed;
    private Integer deg;
    private Long cityid;

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public Date getDt() {
        return dt;
    }

    public void setDt(Date dt) {
        this.dt = dt;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Double getTemperature() {
        return temperature;
    }

    public void setTemperature(Double temperature) {
        this.temperature = temperature;
    }

    public Integer getPressure() {
        return pressure;
    }

    public void setPressure(Integer pressure) {
        this.pressure = pressure;
    }

    public Integer getHumidity() {
        return humidity;
    }

    public void setHumidity(Integer humidity) {
        this.humidity = humidity;
    }

    public Double getTempmin() {
        return tempmin;
    }

    public void setTempmin(Double tempmin) {
        this.tempmin = tempmin;
    }

    public Double getTempmax() {
        return tempmax;
    }

    public void setTempmax(Double tempmax) {
        this.tempmax = tempmax;
    }

    public Double getSpeed() {
        return speed;
    }

    public void setSpeed(Double speed) {
        this.speed = speed;
    }

    public Integer getDeg() {
        return deg;
    }

    public void setDeg(Integer deg) {
        this.deg = deg;
    }

    public Long getCityid() {
        return cityid;
    }

    public void setCityid(Long cityid) {
        this.cityid = cityid;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Weather weather = (Weather) o;
        return id == weather.id &&
                Objects.equals(dt, weather.dt) &&
                Objects.equals(description, weather.description) &&
                Objects.equals(temperature, weather.temperature) &&
                Objects.equals(pressure, weather.pressure) &&
                Objects.equals(humidity, weather.humidity) &&
                Objects.equals(tempmin, weather.tempmin) &&
                Objects.equals(tempmax, weather.tempmax) &&
                Objects.equals(speed, weather.speed) &&
                Objects.equals(deg, weather.deg) &&
                Objects.equals(cityid, weather.cityid);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, dt, description, temperature, pressure, humidity, tempmin, tempmax, speed, deg, cityid);
    }

}
