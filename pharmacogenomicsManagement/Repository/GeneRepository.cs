using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacogenomicsManagement.Models;
using pharmacogenomicsManagement.Services;

namespace pharmacogenomicsManagement.Repository
{
    public class GeneRepository : Repository<Gene>, IGeneRepository
    {
        public GeneRepository(pharmcogeneContext context) : base(context)
        {
        }

        public IEnumerable<Gene> GetAllWithDiplotypes()
        {
            return _context.Gene.Include(a => a.Diplotype);
        }

        Gene IGeneRepository.GetWithDiplotypes(int id)
        {
            return _context.Gene
                    .Where(a => a.GeneId == id)
                    .Include(a => a.Diplotype)
                    .FirstOrDefault();
        }
    }
}
