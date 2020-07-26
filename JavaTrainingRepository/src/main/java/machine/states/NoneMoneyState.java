package machine.states;

import machine.MachineGum;

/**
 * Нет денег в автомате
 */
public class NoneMoneyState implements Station{

    public NoneMoneyState(){
        System.out.println("Нет денег в автомате");
    }

    @Override
    public void doAction(MachineGum machineGum) {
        if (machineGum.getMoney() > 0){
            machineGum.changeStation(new ExistMoneyState());
        }
    }


}
