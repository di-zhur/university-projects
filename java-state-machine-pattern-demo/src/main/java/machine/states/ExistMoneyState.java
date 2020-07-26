package machine.states;

import machine.MachineGum;

/**
 * Есть деньги в автомате
 */
public class ExistMoneyState implements Station {

    public ExistMoneyState(){
        System.out.println("Есть деньги в автомате");
    }

    @Override
    public void doAction(MachineGum machineGum) {
        machineGum.changeStation(new ExtraditeState());
    }

}
