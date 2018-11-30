using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pharmacogenomicsManagement.Models;
using pharmacogenomicsManagement.Services;

namespace pharmacogenomicsManagement.Controllers
{
    public class GeneController : Controller
    {
        private readonly IGeneRepository _GeneRepository;

        public GeneController(IGeneRepository _IGeneRepository)
        {
            _GeneRepository = _IGeneRepository;
        }

        [Route("Gene")]
        public IActionResult Index()
        {
            var genes = _GeneRepository.GetAllWithDiplotypes();

            if (genes.Count() == 0)
                return View("Empty");
            return View(genes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Gene model)
        {
            if (ModelState.IsValid)
            {
                _GeneRepository.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}