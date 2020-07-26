using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    /*
     Паттерн "Абстрактная фабрика" (Abstract Factory) предоставляет интерфейс 
     для создания семейств взаимосвязанных объектов с определенными интерфейсами 
     без указания конкретных типов данных объектов.
     *
     1)Когда система не должна зависеть от способа создания и компоновки новых объектов
     2)Когда создаваемые объекты должны использоваться вместе и являются взаимосвязанными
    */

    public abstract class Sensor
    {
        public abstract void Kit();
    }

    public abstract class Diagnostic
    {
        public abstract void Do();
    }

    public class SensorMfl : Sensor
    {
        public override void Kit()
        {
            throw new NotImplementedException();
        }
    }

    public class SensorWm : Sensor
    {
        public override void Kit()
        {
            throw new NotImplementedException();
        }
    }

    public class DiagnosticMfl : Diagnostic
    {
        public override void Do()
        {
            throw new NotImplementedException();
        }
    }

    public class DiagnosticWm : Diagnostic
    {
        public override void Do()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class EquipmentFactory
    {
        public abstract Sensor CreateSensor();
        public abstract Diagnostic CreateDiagnostic();
    }

    public class MflEquipmentFactory : EquipmentFactory
    {
        public override Diagnostic CreateDiagnostic()
        {
            return new DiagnosticMfl();
        }

        public override Sensor CreateSensor()
        {
            return new SensorMfl();
        }
    }

    public class WmEquipmentFactory : EquipmentFactory
    {
        public override Diagnostic CreateDiagnostic()
        {
            return new DiagnosticWm();
        }

        public override Sensor CreateSensor()
        {
            return new SensorWm();
        }
    }

    public class ClientFactory
    {
        private EquipmentFactory _equipmentFactory;

        public ClientFactory(EquipmentFactory equipmentFactory)
        {
            _equipmentFactory = equipmentFactory;
        }

        public void Create()
        {
            _equipmentFactory.CreateDiagnostic();
            _equipmentFactory.CreateSensor();
        }
    }
}
