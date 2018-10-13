using System;
using System.Collections.Generic;

namespace Jackdaw.DataLayer
{
    public partial class Institution
    {
        public Institution()
        {
            RegisteredParticipant = new HashSet<RegisteredParticipant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RegisteredParticipant> RegisteredParticipant { get; set; }
    }
}
