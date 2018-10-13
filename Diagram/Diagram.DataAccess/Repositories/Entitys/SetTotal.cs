using System;
using System.Collections.Generic;

namespace Diagram.DataAccess.Repositories.Entity
{
    public partial class SetTotal
    {
        public Guid Id { get; set; }
        public Guid SpecialtyId { get; set; }
        public int BudgetPlaces { get; set; }
        public int Request { get; set; }
        public float Mark { get; set; }
        public int PayPlaces { get; set; }
        public int Places { get; set; }
        public DateTime Year { get; set; }
        public float Contest { get; set; }

        public Specialty Specialty { get; set; }
    }
}
