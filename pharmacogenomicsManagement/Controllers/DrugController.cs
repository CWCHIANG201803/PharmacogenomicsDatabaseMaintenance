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
    public class DrugController : Controller
    {
        private readonly IDrugRepository _DrugRepository;
        private readonly IDiplotypeRepository _DiplotypeRepository;
        private readonly IDrugDescriptionRepository _DrugDescriptionRepository;

        public DrugController(IDrugRepository _IDrugRepository, IDiplotypeRepository _IDiplotypeRepository, IDrugDescriptionRepository _IDrugDescriptionRepository)
        {
            _DrugRepository = _IDrugRepository;
            _DiplotypeRepository = _IDiplotypeRepository;
            _DrugDescriptionRepository = _IDrugDescriptionRepository;

        }

        public IActionResult Index()
        {
            var drugVM = new List<DrugViewModel>();
            var drugs = _DrugRepository.GetAll();

            if(drugs.Count()==0)
            {
                return View("Empty");
            }
            return View(_DrugRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Drug model)
        {
            if (ModelState.IsValid)
            {
                _DrugRepository.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}