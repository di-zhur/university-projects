using System;
using System.Collections.Generic;

namespace Diagram.DataAccess.Repositories.Entity
{
    public partial class Statistic
    {
        public Guid Id { get; set; }
        public Guid ClassId { get; set; }
        public string Result { get; set; }
        public Guid UniversityId { get; set; }

        public ClassStatistic Class { get; set; }
        public University University { get; set; }
    }
}
