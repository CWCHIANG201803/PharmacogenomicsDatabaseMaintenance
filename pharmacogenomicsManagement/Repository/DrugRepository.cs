using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pharmacogenomicsManagement.Models;
using pharmacogenomicsManagement.Services;

namespace pharmacogenomicsManagement.Repository
{
    public class DrugRepository : Repository<Drug>, IDrugRepository
    {
        public DrugRepository(pharmcogeneContext context) : base(context) { }
    }
}
