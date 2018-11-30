using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IDrug
    {
        IEnumerable<Drug> GetDrugs { get; }
        Drug GetDrug(string ATC_CODE);
        void Add(Drug _Drug);
        void Remove(string ATC_CODE);
    }
}
