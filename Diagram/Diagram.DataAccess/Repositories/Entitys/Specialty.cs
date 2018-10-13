using System;
using System.Collections.Generic;

namespace Diagram.DataAccess.Repositories.Entity
{
    public partial class Specialty
    {
        public Specialty()
        {
            SetTotal = new HashSet<SetTotal>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid FacultyId { get; set; }
        public string Options { get; set; }

        public Faculty Faculty { get; set; }
        public ICollection<SetTotal> SetTotal { get; set; }
    }
}
