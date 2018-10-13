using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Entity
{
    public class Cat : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CatItem> Skills { get; set; }
    }

    public class CatItem
    {
        public string Skill { get; set; }
    }

    public class ParamsCat : IParamsEntitys<Cat, CatItem>
    {
        public CatItem Get()
        {
            throw new NotImplementedException();
        }

        public Cat GetMain()
        {
            throw new NotImplementedException();
        }
    }
}
