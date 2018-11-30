using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacogenomicsManagement.Models;


namespace pharmacogenomicsManagement.Services
{
    public interface IDrugDescriptionRepository : IRepository<DrugDescription>
    {
        IEnumerable<DrugDescription> FindWithGeneInfo(Func<DrugDescription, bool> predicate);
        IEnumerable<DrugDescription> GetAWithGeneInfoAndDrug();
        IEnumerable<DrugDescription> GetWithDrug();
        DrugDescription GetWithDiplotypes(string atccode);
    }
}