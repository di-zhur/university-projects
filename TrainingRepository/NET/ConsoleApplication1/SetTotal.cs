namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SetTotal")]
    public partial class SetTotal
    {
        public Guid Id { get; set; }

        public Guid SpecialtyId { get; set; }

        public int BudgetPlaces { get; set; }

        public int Request { get; set; }

        public float Mark { get; set; }

        public int PayPlaces { get; set; }

        public int Places { get; set; }

        [Column(TypeName = "date")]
        public DateTime Year { get; set; }

        public float Contest { get; set; }

        public virtual Specialty Specialty { get; set; }
    }
}
