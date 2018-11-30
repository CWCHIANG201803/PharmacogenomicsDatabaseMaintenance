using System;
using System.Collections.Generic;

namespace pharmacogenomicsManagement.Models
{
    public partial class Gene
    {
        public Gene()
        {
            Diplotype = new HashSet<Diplotype>();
        }

        public int GeneId { get; set; }
        public string GeneName { get; set; }

        public ICollection<Diplotype> Diplotype { get; set; }
    }
}
