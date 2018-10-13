namespace Delta.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Statistic")]
    public partial class Statistic
    {
        public Guid Id { get; set; }

        public Guid ClassId { get; set; }

        public string Result { get; set; }

        public Guid UniversityId { get; set; }

        public virtual ClassStatistic ClassStatistic { get; set; }

        public virtual University University { get; set; }
    }
}
