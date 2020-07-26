using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class ImportContext
    {
        private Strategy strategy;
        private dynamic parameters;

        public ImportContext(Strategy strategy, dynamic parameters)
        {
            this.strategy = strategy;
            this.parameters = parameters;
        }

        public void Execute()
        {
            strategy.Import(parameters);
        }
    }
}
