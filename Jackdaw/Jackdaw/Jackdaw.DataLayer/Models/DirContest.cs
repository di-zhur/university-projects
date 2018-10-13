using System;
using System.Collections.Generic;

namespace Jackdaw.DataLayer
{
    public partial class DirContest
    {
        public DirContest()
        {
            DirNomination = new HashSet<DirNomination>();
        }

        public int Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<DirNomination> DirNomination { get; set; }
    }
}
