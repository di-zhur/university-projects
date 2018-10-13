using System;
using System.Collections.Generic;

namespace Jackdaw.DataLayer
{
    public partial class RegisteredParticipant
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int RegisteredContestId { get; set; }
        public int InstitutionId { get; set; }
        public string NameWork { get; set; }
        public string Comment { get; set; }
        public string Marks { get; set; }
        public float? Mark { get; set; }

        public Institution Institution { get; set; }
        public Participant Participant { get; set; }
        public RegisteredContest RegisteredContest { get; set; }
    }
}
