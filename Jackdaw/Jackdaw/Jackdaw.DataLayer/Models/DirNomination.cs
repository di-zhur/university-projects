using System;
using System.Collections.Generic;

namespace Jackdaw.DataLayer
{
    public partial class DirNomination
    {
        public DirNomination()
        {
            RegisteredContest = new HashSet<RegisteredContest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ContestId { get; set; }
        public string Option { get; set; }

        public DirContest Contest { get; set; }
        public ICollection<RegisteredContest> RegisteredContest { get; set; }
    }
}
