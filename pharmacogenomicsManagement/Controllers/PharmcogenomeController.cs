using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pharmacogenomicsManagement.Models;
using pharmacogenomicsManagement.Services;
using pharmacogenomicsManagement.ViewModel;

namespace pharmacogenomicsManagement.Controllers
{
    public class PharmcogenomeController : Controller
    {
        private readonly IGeneRepository _geneRepository;
        private readonly IDiplotypeRepository _diplotypeRepository;
        private readonly IDrugRepository _drugRepository;
        private readonly IDrugDescriptionRepository _drugDescriptionRepository;

        public PharmcogenomeController(IGeneRepository geneRepository, IDiplotypeRepository diplotypeRepository, IDrugRepository drugRepository, IDrugDescriptionRepository drugDescriptionRepository)
        {
            _geneRepository = geneRepository;
            _diplotypeRepository = diplotypeRepository;
            _drugRepository = drugRepository;
            _drugDescriptionRepository = drugDescriptionRepository;
        }
        [Route("Pharmcogenome")]
        public IActionResult Index(string atccode)
        {
            var DrugGeneVM = new List<DrugGeneViewModel>();
            // 可以用一個像是view model的東西把他們給combine起來

            IEnumerable<Diplotype> drugGenes = _diplotypeRepository.FindWithDrugInfo(atccode);
            

            
            if (drugGenes.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var drugGene in drugGenes)
            {
                DrugGeneVM.Add(new DrugGeneViewModel
                {
                    GeneName = _geneRepository.GetById(drugGene.GeneId).GeneName,
                    Diplotype = drugGene
                });
            }
            return View(DrugGeneVM);
        }
    }
}