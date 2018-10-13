using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jackdaw.WebApi.Models
{
    public class СalculatedParticipant
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public string NameWork { get; set; }
        public string Institution { get; set; }
        public string Marks { get; set; }
        public float? Mark { get; set; }
        public int? Place { get; set; }
    }
}
