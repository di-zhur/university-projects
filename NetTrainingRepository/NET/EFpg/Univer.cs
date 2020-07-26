namespace EFpg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("university.Univer")]
    public partial class Univer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Univer()
        {
            Analytic = new HashSet<Analytic>();
            Cathedra = new HashSet<Cathedra>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? CityId { get; set; }

        public string FullName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Analytic> Analytic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cathedra> Cathedra { get; set; }

        public virtual City City { get; set; }
    }
}
