using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pharmacogenomicsManagement.Models;
using pharmacogenomicsManagement.Services;

namespace pharmacogenomicsManagement.Controllers
{
    public class DiplotypeController : Controller
    {
        private readonly IDiplotypeRepository _diplotypeRepository;
        private readonly IGeneRepository _geneRepository;
        private readonly IDrugDescriptionRepository _drugDescriptionRepository;
        private readonly IDrugRepository _drugRepository;

        public DiplotypeController(IDiplotypeRepository _IdiplotypeRepository, IGeneRepository _IgeneRepository ,IDrugRepository _IdrugRepository ,IDrugDescriptionRepository _IdrugDescriptionRepository)
        {
            _geneRepository = _IgeneRepository;
            _diplotypeRepository = _IdiplotypeRepository;
            _drugDescriptionRepository = _IdrugDescriptionRepository;
            _drugRepository = _IdrugRepository;

        }

        [Route("Diplotype")]
        public IActionResult Index(int? GeneId,string atccode)
        {
            if (GeneId == null&& atccode ==string.Empty)
            {
                var diplotypes = _diplotypeRepository.GetAllwithGene();

                return CheckDiplotypes(diplotypes);
            }
            // view list 是route 到這段
            else if (GeneId != null)
            {
                var gene = _geneRepository
                    .GetWithDiplotypes((int)GeneId);
                
                if(gene.Diplotype.Count() == 0){
                    return View("GeneEmpty",gene);
                }
                else{
                    return View(gene.Diplotype);
                }
            }
            else if (atccode !=string.Empty)
            {
                var drug = _diplotypeRepository
                   .FindWithDrugInfo(atccode);
                return View(drug);
            }
            else
            {
                // throw exception
                throw new ArgumentException();
            }
        }

        public IActionResult CheckDiplotypes(IEnumerable<Diplotype> diplotypes)
        {
            if (diplotypes.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(diplotypes);
            }
        }

    }
}