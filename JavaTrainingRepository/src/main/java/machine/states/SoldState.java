package machine.states;

import machine.MachineGum;

/**
 * Жвачка продана
 */
public class SoldState implements Station{

    public SoldState(){
        System.out.println("Жвачка продана");
    }

    @Override
    public void doAction(MachineGum machineGum) {
        machineGum.changeStation(new NoneMoneyState());
    }

}
