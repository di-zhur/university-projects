package sample;

import javafx.application.Platform;
import javafx.scene.shape.Circle;

import java.util.Random;
import java.util.Set;


public class GameField {
    public static final int BALLRADIUS = 10;
    private int sizeX;
    private int sizeY;
    private Set<Ball> balls;

    public GameField(int sizeX, int sizeY, Set<Ball> balls) {
        this.sizeX = sizeX;
        this.sizeY = sizeY;
        this.balls = balls;
    }

    public int getSizeY() {
        return sizeY;
    }

    public int getSizeX() {
        return sizeX;
    }

    public synchronized void changePlace(Ball ball) {
        double offset = 2 * BALLRADIUS;
        double[] offsets = { -offset, offset };
        Random random = new Random();
        double coordX = ball.getPositionX() + offsets[random.nextInt(2)];
        double coordY = ball.getPositionY() + offsets[random.nextInt(2)];

        boolean isChange = false;

        if (sizeX >= coordX && sizeY >= coordY && coordX >= BALLRADIUS && coordY >= BALLRADIUS){

            for (Ball item : balls){
                if (Math.abs(item.getPositionY() - coordY) >= offset || Math.abs(item.getPositionX() - coordX) >= offset){
                    isChange = true;
                } else {
                    isChange = false;
                    break;
                }
            }

        }

        if (isChange){
            ball.setPositionX(coordX);
            ball.setPositionY(coordY);
            drawField();
        }
    }

    /*
    * В просторах google по обновлению UI активно используется Platform.runLater, также есть вариант решения с Task
    * Решил оставить так...
    * Решение: getChildren().clear(), затем getChildren().add(circle) не лучший вариант, но пусть будет так.
    * Это всего лишь метод для отрисовки, основная логика в synchronized void changePlace(Ball ball)
    * Возможно не понял основной задачи т.к. все сводится к запуску потоков и написанию одного synchronized метода((
    * */
    private void drawField(){
        Platform.runLater(() -> {
            MainView.canvas.getChildren().clear();
            for (Ball item : balls){
                Circle circle = new Circle(item.getPositionX(), item.getPositionY(), GameField.BALLRADIUS, item.getColor());
                MainView.canvas.getChildren().add(circle);
            }
        });
    }
}
