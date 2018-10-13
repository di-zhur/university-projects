using System;
using System.Collections.Generic;

namespace Mds.DataAccess.Entitys
{
    public partial class ModelVersion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelId { get; set; }
        public bool IsWorked { get; set; }

        public Model Model { get; set; }
    }
}
