using System;
using System.Collections.Generic;

namespace Diagram.DataAccess.Repositories.Entity
{
    public partial class University
    {
        public University()
        {
            Faculty = new HashSet<Faculty>();
            Statistic = new HashSet<Statistic>();
        }

        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CityId { get; set; }

        public City City { get; set; }
        public ICollection<Faculty> Faculty { get; set; }
        public ICollection<Statistic> Statistic { get; set; }
    }
}
