using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jackdaw.WebApi.Models
{
    public class PostRegisteredParticipant
    {
        public string Fio { get; set; }
        public string Email { get; set; }
        public string NameWork { get; set; }
        public int InstitutionId { get; set; }
        public int RegisteredContestId { get; set; }
        public string Comment { get; set; }
    }
}
