namespace EFpg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("analytic.Analytic")]
    public partial class Analytic
    {
        public Guid Id { get; set; }

        public Guid? UniverId { get; set; }

        public Guid? ClassId { get; set; }

        public virtual ClassAnalytic ClassAnalytic { get; set; }

        public virtual Univer Univer { get; set; }
    }
}
