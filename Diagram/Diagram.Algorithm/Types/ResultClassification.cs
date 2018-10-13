using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.Algorithm.Types
{
    public class ResultClassification
    {
        public Dictionary<string, string> Group { get; set; }

        public List<AnalysisClassification> Specialties { get; set; }
    }
}
