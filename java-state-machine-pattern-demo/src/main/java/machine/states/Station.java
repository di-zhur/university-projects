package machine.states;

import machine.MachineGum;

/*
* Решил не раздувать интерфейс, логика в doAction в какое состояние перейдем и что сделаем
* */
public interface Station {

    void doAction(MachineGum machineGum);

}
