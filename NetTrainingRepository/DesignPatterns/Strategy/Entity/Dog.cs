using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Entity
{
    public class Dog : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class ParamsDog : IParamsEntity<Dog>
    {
        public Dog Get()
        {
            throw new NotImplementedException();
        }
    }
}
