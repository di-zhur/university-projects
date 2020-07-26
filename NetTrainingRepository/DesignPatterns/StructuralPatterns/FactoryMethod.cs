using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    /*
     * Фабричный метод (Factory Method) - это паттерн, 
     * который определяет интерфейс для создания объектов некоторого класса, 
     * но непосредственное решение о том, объект какого класса создавать происходит в подклассах. 
     * То есть паттерн предполагает, что базовый класс делегирует создание объектов классам-наследникам.
     * 
     1)Когда заранее неизвестно, объекты каких типов необходимо создавать
     2)Когда система должна быть независимой от процесса создания новых объектов и расширяемой: 
     в нее можно легко вводить новые классы, объекты которых система должна создавать.
     3)Когда создание новых объектов необходимо делегировать из базового класса классам наследникам
    */

    class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            House house2 = dev.Create();

            dev = new WoodDeveloper("Частный застройщик");
            House house = dev.Create();

            Console.ReadLine();
        }
    }
    
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n)
        {
            Name = n;
        }
       
        abstract public House Create();
    }
    

    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new PanelHouse();
        }
    }

    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    abstract class House
    { }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        }
    }
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }
}
