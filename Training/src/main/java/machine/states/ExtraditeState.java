package machine.states;


import machine.MachineGum;

/**
 * Выдавать жвачку
 */
public class ExtraditeState implements Station {

    public ExtraditeState(){
        System.out.println("Выдавать жвачку, Ожидайте...............");
    }

    @Override
    public void doAction(MachineGum machineGum) {
        //Если есть в атомате жвачки, то выдаю
        if (machineGum.hasGum()) {
            //Проверяю выиграл приз и могу ли я его дать, если дать не могу, то даю одну упаковку(
            if (machineGum.isBingo() && machineGum.hasGum()) {
                machineGum.changeStation(new PrizeSoldState());
            } else {
                machineGum.changeStation(new SoldState());
            }
        } else {
            machineGum.changeStation(new EmptyMachineState());
        }
    }

}
