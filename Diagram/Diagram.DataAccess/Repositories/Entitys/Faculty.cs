using System;
using System.Collections.Generic;

namespace Diagram.DataAccess.Repositories.Entity
{
    public partial class Faculty
    {
        public Faculty()
        {
            Specialty = new HashSet<Specialty>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid UniversityId { get; set; }

        public Specialization Specialization { get; set; }
        public University University { get; set; }
        public ICollection<Specialty> Specialty { get; set; }
    }
}
