using pharmacogenomicsManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacogenomicsManagement.ViewModel
{
    public class DrugGeneViewModel
    {
        [Key]
        public string GeneName { get; set; }
        public Diplotype Diplotype { get; set; }
        
    }
}
