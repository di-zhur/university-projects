namespace EFpg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("university.RefSpecialtyProfession")]
    public partial class RefSpecialtyProfession
    {
        public Guid Id { get; set; }

        public Guid? SpecialtyId { get; set; }

        public Guid? ProfessionId { get; set; }

        public virtual DirProfession DirProfession { get; set; }

        public virtual Specialty Specialty { get; set; }
    }
}
