using Diagram.DataAccess;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.Algorithm.Algorithm
{
    public abstract class BaseAlgorithm
    {
        protected string Result { get; set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected BaseAlgorithm()
        {
            UnitOfWork = new UnitOfWork();
        }

        public virtual string GetResult()
        {
            return Result;
        }
        
        public abstract void Execute(IDictionary<string, string> parameters = null);
    }
}
