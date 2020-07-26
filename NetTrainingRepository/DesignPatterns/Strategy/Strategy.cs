using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public abstract class Strategy
    {
        public abstract string Name { get; }

        public abstract void Import(dynamic d);
    }
}
