using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacogenomicsManagement.Models;
using pharmacogenomicsManagement.Services;

namespace pharmacogenomicsManagement.Repository
{
    public class DiplotypeRepository : Repository<Diplotype>, IDiplotypeRepository
    {
        public DiplotypeRepository(pharmcogeneContext context) : base(context)
        {
        }

        public IEnumerable<Diplotype> FindWithDrugInfo(string atccode)
        {
            IEnumerable<Diplotype> data = (from x in _context.Diplotype
                        join y in _context.DrugDescription on x.DiplotypeId equals y.DiplotypeId
                        where y.AtcCode == atccode
                        select x);
            return data;
        }


        // Func<Diplotype,bool> predicate的意思是一個delegate
        // 其中, Diplotype是輸入引數，
        // 然後bool是回傳值
        public IEnumerable<Diplotype> FindWithGene(Func<Diplotype, bool> predicate)
        {
            return _context.Diplotype
                .Include(a => a.Gene)
                .Where(predicate);
        }

        public IEnumerable<Diplotype> GetAllwithGene()
        {
            return _context.Diplotype.Include(a => a.Gene);
        }



    }
}
