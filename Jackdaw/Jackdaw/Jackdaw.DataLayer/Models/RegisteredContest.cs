using System;
using System.Collections.Generic;

namespace Jackdaw.DataLayer
{
    public partial class RegisteredContest
    {
        public RegisteredContest()
        {
            RegisteredParticipant = new HashSet<RegisteredParticipant>();
        }

        public int Id { get; set; }
        public int NominationId { get; set; }
        public DateTime СompletionDate { get; set; }

        public DirNomination Nomination { get; set; }
        public ICollection<RegisteredParticipant> RegisteredParticipant { get; set; }
    }
}
