using System;
using System.Collections.Generic;

namespace pharmacogenomicsManagement.Models
{
    public partial class Diplotype
    {
        public Diplotype()
        {
            DrugDescription = new HashSet<DrugDescription>();
        }

        public int DiplotypeId { get; set; }
        public int GeneId { get; set; }
        public string Diplotype1 { get; set; }
        public string Diplotype2 { get; set; }

        public Gene Gene { get; set; }
        public ICollection<DrugDescription> DrugDescription { get; set; }
    }
}
