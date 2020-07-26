package machine.states;

import machine.MachineGum;

/**
 * Нет жвачки автомате
 */
public class EmptyMachineState implements Station {

    public EmptyMachineState() {
        System.out.println("Нет жвачки в автомате");
    }

    @Override
    public void doAction(MachineGum machineGum) {
        machineGum.changeStation(new NoneMoneyState());
    }

}
