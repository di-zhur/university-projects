namespace EFpg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cathedra", Schema = "university")]
    public partial class Cathedra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cathedra()
        {
            Specialty = new HashSet<Specialty>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? UniverId { get; set; }

        public Guid? SpecializationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specialty> Specialty { get; set; }

        public virtual Univer Univer { get; set; }

        public virtual DirSpecialization DirSpecialization { get; set; }
    }
}
