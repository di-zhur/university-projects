namespace Delta.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Profession")]
    public partial class Profession
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid SpecializationId { get; set; }

        public virtual Specialization Specialization { get; set; }
    }
}
