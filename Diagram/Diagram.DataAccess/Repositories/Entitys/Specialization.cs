using System;
using System.Collections.Generic;

namespace Diagram.DataAccess.Repositories.Entity
{
    public partial class Specialization
    {
        public Specialization()
        {
            Faculty = new HashSet<Faculty>();
            Profession = new HashSet<Profession>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Faculty> Faculty { get; set; }
        public ICollection<Profession> Profession { get; set; }
    }
}
