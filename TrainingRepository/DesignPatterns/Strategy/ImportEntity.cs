using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategy.Entity;

namespace Strategy
{
    public class ImportEntity<T> : Strategy where T : class 
    {
        public override string Name { get; } = "Одна таблица";

        public override void Import(dynamic d)
        {
            var param = d as IParamsEntity<T>;
            //.....и так далее
        }
    }
}
