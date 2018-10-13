namespace Delta.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FrecastParameters
    {
        public Guid Id { get; set; }

        [Required]
        public string Parameters { get; set; }

        public Guid? FrecastId { get; set; }

        public virtual Frecast Frecast { get; set; }
    }
}
