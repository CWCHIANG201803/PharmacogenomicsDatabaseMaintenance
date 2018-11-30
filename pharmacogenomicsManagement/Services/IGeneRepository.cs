using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacogenomicsManagement.Models;

namespace pharmacogenomicsManagement.Services
{
    public interface IGeneRepository : IRepository<Gene>
    {

        IEnumerable<Gene> GetAllWithDiplotypes();
        Gene GetWithDiplotypes(int id);
        // 這個應該不會實作
        // 未必會用diplotype來搜尋基因!
        //IEnumerable<Gene> GetAllWithDiplotypes();
        //Gene GetWithDiplotypes(int id);
    }
}
