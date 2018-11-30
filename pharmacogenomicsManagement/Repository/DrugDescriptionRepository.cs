using Microsoft.EntityFrameworkCore;
using pharmacogenomicsManagement.Models;
using pharmacogenomicsManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacogenomicsManagement.Repository
{
    public class DrugDescriptionRepository : Repository<DrugDescription>, IDrugDescriptionRepository
    {
        public DrugDescriptionRepository(pharmcogeneContext context) : base(context)
        {
        }

        public IEnumerable<DrugDescription> FindWithGeneInfo(Func<DrugDescription, bool> predicate)
        {
            return _context.DrugDescription
                .Include(a => a.Diplotype.Gene)
                .Include(a => a.Diplotype)
                .Where(predicate);
        }

        public IEnumerable<DrugDescription> GetAWithGeneInfoAndDrug()
        {
            return _context.DrugDescription
                .Include(a => a.Diplotype.Gene)
                .Include(a => a.Diplotype)
                .Include(a => a.AtcCode);

        }

        public DrugDescription GetWithDiplotypes(string atccode)
        {
            return _context.DrugDescription
                .Where(a => a.AtcCode == atccode)
                .Include(a => a.Diplotype)
                .FirstOrDefault();
        }

        // 這個預期會回傳同個藥品下多個基因還有基因型對應
        public IEnumerable<DrugDescription> GetWithDrug()
        {
            return _context.DrugDescription.Include(a => a.AtcCode);
        }

    }
}
