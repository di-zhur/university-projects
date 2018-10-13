using System;
using System.Collections.Generic;

namespace Jackdaw.DataLayer
{
    public partial class Participant
    {
        public Participant()
        {
            RegisteredParticipant = new HashSet<RegisteredParticipant>();
        }

        public int Id { get; set; }
        public string Fio { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public ICollection<RegisteredParticipant> RegisteredParticipant { get; set; }
    }
}
