package machine;

import machine.entitys.Dirol;
import machine.entitys.Orbit;


public class Main {
    /*
    * Если представить автомат, то у него есть кнопки и функции:
     * Забрать деньги - putMoney
     * Доложить деньги - addMoney
     * Кнопка вернуть деньги - returnMoney
     * Кнопка запустить, тыкнуть, которая даст жвачку или не дасть - execute
    * */
    public static void main(String[] args) {
        example1();
        //example2();
        //example3();
    }

    /*
    * Когда все хорошо
    * */
    private static void example1(){
        MachineGum machineGum = new MachineGum(new Orbit());
        machineGum.putMoney(30);
        machineGum.execute();
    }

    /*
    * Когда нехватило и доложили
    * */
    private static void example2(){
        MachineGum machineGum = new MachineGum(new Dirol());
        machineGum.putMoney(15);
        machineGum.execute();
        //доложим 10
        machineGum.addMoney(10);
        machineGum.execute();
    }

    /*
    * Когда вернули деньги и поехали на маршрутке)
    * */
    private static void example3(){
        MachineGum machineGum = new MachineGum(new Dirol());
        machineGum.putMoney(25);
        machineGum.returnMoney();
        machineGum.execute();
    }
}
