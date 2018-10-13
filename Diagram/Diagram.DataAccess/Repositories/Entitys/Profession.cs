using System;
using System.Collections.Generic;

namespace Diagram.DataAccess.Repositories.Entity
{
    public partial class Profession
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SpecializationId { get; set; }

        public Specialization Specialization { get; set; }
    }
}
