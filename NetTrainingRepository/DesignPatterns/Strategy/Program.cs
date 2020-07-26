using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategy.Entity;

namespace Strategy
{
    //паттерн для импорта данных
    class Program
    {
        static void Main(string[] args)
        {
            var importDog = new ImportContext(new ImportEntity<Dog>(), new ParamsDog());
            importDog.Execute();
        }
    }
}
