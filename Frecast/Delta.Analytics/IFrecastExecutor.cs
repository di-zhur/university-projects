using Delta.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delta.Analytics
{
    public interface IFrecastExecutor
    {
        void Do();
        List<FrecastSeries> GetResult();
    }
}
