using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacogenomicsManagement.Models;


namespace pharmacogenomicsManagement.ViewModel
{
    // view model的功用是用來重新組合顯示某個頁面上所需要的元素
    // 這樣子做不會動到原本database的model
    public class DrugViewModel
    {
        public Drug Drug { get; set; }
        public Diplotype Diplotype { get; set; }
        public int GeneDiplotypeCount { get; set; }
    }
}
