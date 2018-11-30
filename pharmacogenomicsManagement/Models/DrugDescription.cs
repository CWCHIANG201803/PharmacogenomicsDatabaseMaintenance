using System;
using System.Collections.Generic;

namespace pharmacogenomicsManagement.Models
{
    public partial class DrugDescription
    {
        public int DiplotypeId { get; set; }
        public string AtcCode { get; set; }
        public string ActivityScore { get; set; }
        public string Phenotype { get; set; }
        public string TherapeuticRecommendations { get; set; }
        public string ClassificationOfRecommendations { get; set; }
        public string Alternative { get; set; }
        public string Message { get; set; }

        public Drug AtcCodeNavigation { get; set; }
        public Diplotype Diplotype { get; set; }
    }
}
