using System;
using System.Collections.Generic;

namespace pharmacogenomicsManagement.Models
{
    public partial class Drug
    {
        public Drug()
        {
            DrugDescription = new HashSet<DrugDescription>();
        }

        public string AtcCode { get; set; }
        public string DrugName { get; set; }

        public ICollection<DrugDescription> DrugDescription { get; set; }
    }
}
