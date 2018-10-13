using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delta.Types
{
    public class AreaExcel
    {
        public int StartColumn { get; set; }
        public int StartRow { get; set; }
        public int EndColumn { get; set; }
        public int EndRow { get; set; }
    }
}
