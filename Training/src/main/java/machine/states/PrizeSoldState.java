package machine.states;

import machine.MachineGum;

/**
 * Жвачка продана + вторая в подарок
 */
public class PrizeSoldState implements Station{

    public PrizeSoldState(){
        System.out.println("Жвачка продана + вторая в подарок");
    }

    @Override
    public void doAction(MachineGum machineGum) {
        machineGum.changeStation(new NoneMoneyState());
    }

}
