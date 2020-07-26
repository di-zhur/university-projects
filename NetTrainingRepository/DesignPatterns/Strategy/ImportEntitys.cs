using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategy.Entity;

namespace Strategy
{
    public class ImportEntitys<TMain, TItem> : Strategy where TMain : class where TItem : class
    {
        public override string Name { get; } = "Связанные таблицы";

        public override void Import(dynamic d)
        {   
            var param = d as IParamsEntitys<TMain, TItem>;
            //.....и так далее
        }
    }
}
