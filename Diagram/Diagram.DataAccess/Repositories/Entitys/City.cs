using System;
using System.Collections.Generic;

namespace Diagram.DataAccess.Repositories.Entity
{
    public partial class City
    {
        public City()
        {
            University = new HashSet<University>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Coordinates { get; set; }

        public ICollection<University> University { get; set; }
    }
}
