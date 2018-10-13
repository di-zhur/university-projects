namespace Delta.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FrecastDb : DbContext
    {
        public FrecastDb()
            : base("name=Data")
        {
        }

        public virtual DbSet<Frecast> Frecast { get; set; }
        public virtual DbSet<FrecastData> FrecastData { get; set; }
        public virtual DbSet<FrecastError> FrecastError { get; set; }
        public virtual DbSet<FrecastParameters> FrecastParameters { get; set; }
        public virtual DbSet<FrecastResult> FrecastResult { get; set; }
        public virtual DbSet<FrecastState> FrecastState { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
