package machine;

import machine.entitys.Gum;
import machine.states.ExistMoneyState;
import machine.states.NoneMoneyState;
import machine.states.Station;

import java.util.Random;


public class MachineGum {

    private final static int PACK_ONE = 1;
    private Station station;
    private static int countGums = 10;
    private Gum gum;
    private int money;

    public MachineGum(Gum gum){
        machineInfo();
        this.gum = gum;
        station = new NoneMoneyState();
    }

    /*
    * Положить деньги в автомат
    * */
    public void putMoney(int var) {
        money = var;
        System.out.format("Положили денег: %d%n", money);
        station.doAction(this);
    }

    public int getMoney() {
        return money;
    }

    /*
    * Доложить деньги, когда не хватило на жвачку
    * */
    public void addMoney(int var){
        money = money + var;
        System.out.format("Денег в автомате: %d%n", money);
    }

    /*
    * Вернуть деньги из автомата
    * */
    public void returnMoney() {
        //Возвращать деньги можно только в state "Есть деньги - ExistMoneyState" т.к. в других state "работает, думает" или денег нет!
        if (station instanceof ExistMoneyState){
            setMoneyZero();
            station = new NoneMoneyState();
        } else {
            System.out.println("Деньги вернуть незя");
        }
    }

    /*
    * Нажали кнопку выдать жвачку, рычаг на схеме
    * */
    public void execute() {
        //Зпустить на выдачу можно в том случае, если в автомат положили деньги
        if (station instanceof ExistMoneyState) {
            //Внутренняя работа автомата, процесс выдачи и т.д. - она клиенту не нужна
            onClickGive();

            if (money >= gum.getPrice()) {
                extradite();
                resultExtradite();
                setMoneyZero();
            } else {
                //Можно было бы новый state - когда денег мало, но пусть будет так))
                //По задумке клиент может доложить денег через addMoney и выполнить опять execute
                System.out.println("Не хватило денег!");
                station = new ExistMoneyState();
            }

        }
    }

    private void onClickGive() {
        station.doAction(this);
    }

    private void extradite() {
        station.doAction(this);
    }

    private void resultExtradite() {
        station.doAction(this);
        System.out.format("Осталось жвачки в автомате: %d%n", countGums);
    }

    /*
    * Когда выпал приз
    * */
    public boolean isBingo() {
        Random rnd = new Random(System.currentTimeMillis());
        final int bingoRandomLimit = 10;
        int varRandom = rnd.nextInt(bingoRandomLimit);
        return varRandom == 0 ? true : false;
    }

    public Station getStation() {
        return station;
    }

    public void changeStation(Station station) {
        this.station = station;
    }

    public boolean hasGum() {
        int ratio = countGums - PACK_ONE;
        if (ratio > 0) {
            countGums = ratio;
            return true;
        }
        return false;
    }

    private void setMoneyZero() {
        money = 0;
    }

    private void machineInfo() {
        System.out.format("Количество жвачки в автомате: %d%n", countGums);
    }
}
