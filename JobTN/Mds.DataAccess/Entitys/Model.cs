using System;
using System.Collections.Generic;

namespace Mds.DataAccess.Entitys
{
    public partial class Model
    {
        public Model()
        {
            ModelVersion = new HashSet<ModelVersion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ModelVersion> ModelVersion { get; set; }
    }
}
