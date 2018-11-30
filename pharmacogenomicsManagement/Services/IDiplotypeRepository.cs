using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacogenomicsManagement.Models;

namespace pharmacogenomicsManagement.Services
{
    public interface IDiplotypeRepository : IRepository<Diplotype>
    {
        IEnumerable<Diplotype> FindWithGene(Func<Diplotype, bool> predicate);
        IEnumerable<Diplotype> GetAllwithGene();
        IEnumerable<Diplotype> FindWithDrugInfo(string atccode);
    }
}
