package sample;


public class Player implements Runnable{
    private Ball ball;
    private GameField field;
    private long timeToSleepMs;

    public Player(Ball ball, GameField field, long timeToSleepMs) {
        this.ball = ball;
        this.field = field;
        this.timeToSleepMs = timeToSleepMs;
    }

    @Override
    public void run() {
        while(true) {
            try {
                Thread.sleep(timeToSleepMs);
                field.changePlace(ball);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}
