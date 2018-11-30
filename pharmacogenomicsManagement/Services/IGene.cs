using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IGene
    {
        IEnumerable<Gene> GetGenes { get; }
        Gene GetGene(int id);
        void Add(Gene _Gene);
        void Remove(int id);
    }
}
