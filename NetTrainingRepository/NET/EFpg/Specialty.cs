namespace EFpg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("university.Specialty")]
    public partial class Specialty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Specialty()
        {
            RefSpecialtyProfession = new HashSet<RefSpecialtyProfession>();
            SetTotal = new HashSet<SetTotal>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? CathedraId { get; set; }

        public Guid? ClassTeachingId { get; set; }

        public virtual Cathedra Cathedra { get; set; }

        public virtual ClassTeaching ClassTeaching { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefSpecialtyProfession> RefSpecialtyProfession { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SetTotal> SetTotal { get; set; }
    }
}
