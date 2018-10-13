namespace Delta.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FrecastData")]
    public partial class FrecastData
    {
        public Guid Id { get; set; }

        [Required]
        public string Data { get; set; }

        public Guid? FrecastId { get; set; }

        public virtual Frecast Frecast { get; set; }
    }
}
