package sample;

import javafx.application.Application;
import javafx.application.Platform;
import javafx.scene.Scene;
import javafx.scene.layout.Pane;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;
import javafx.stage.Stage;

import java.util.Arrays;
import java.util.HashSet;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class MainView extends Application {

    public static Pane canvas = new Pane();

    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        Ball ball1 = new Ball(10,10, Color.RED);
        Ball ball2 = new Ball(40,50, Color.BLUE);
        Ball ball3 = new Ball(80,80, Color.BLACK);
        Ball ball4 = new Ball(190,50, Color.GOLD);
        Ball ball5 = new Ball(120,200, Color.GREEN);
        GameField field = new GameField(60, 60, new HashSet<>(Arrays.asList(ball1, ball2, ball3, ball4, ball5)));

        Scene scene = new Scene(canvas, field.getSizeX(), field.getSizeY());
        primaryStage.setTitle("Balls");
        primaryStage.setResizable(false);
        primaryStage.setScene(scene);
        primaryStage.show();

        ExecutorService threadExecutor = Executors.newFixedThreadPool(5);
        threadExecutor.execute(new Player(ball1, field, 350));
        threadExecutor.execute(new Player(ball2, field, 550));
        threadExecutor.execute(new Player(ball3, field, 450));
        threadExecutor.execute(new Player(ball4, field, 600));
        threadExecutor.execute(new Player(ball5, field, 650));
    }





}
