using System;
using System.Collections.Generic;

namespace Diagram.DataAccess.Repositories.Entity
{
    public partial class ClassStatistic
    {
        public ClassStatistic()
        {
            Statistic = new HashSet<Statistic>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Statistic> Statistic { get; set; }
    }
}
