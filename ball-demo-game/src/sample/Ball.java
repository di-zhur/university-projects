package sample;

import javafx.scene.paint.*;


public class Ball {

    private double positionX;
    private double positionY;
    private Color color;


    public Ball(int positionX, int positionY, Color color) {
        this.positionX = positionX;
        this.positionY = positionY;
        this.color = color;
    }

    public double getPositionX() {
        return positionX;
    }

    public void setPositionX(double positionX) {
        this.positionX = positionX;
    }

    public double getPositionY() {
        return positionY;
    }

    public void setPositionY(double positionY) {
        this.positionY = positionY;
    }

    public Color getColor() {
        return color;
    }


}
