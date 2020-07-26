namespace EFpg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("university.DirProfession")]
    public partial class DirProfession
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DirProfession()
        {
            RefSpecialtyProfession = new HashSet<RefSpecialtyProfession>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? SpecializationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefSpecialtyProfession> RefSpecialtyProfession { get; set; }

        public virtual DirSpecialization DirSpecialization { get; set; }
    }
}
