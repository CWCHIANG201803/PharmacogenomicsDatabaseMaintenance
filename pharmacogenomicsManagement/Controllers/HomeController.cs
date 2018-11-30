using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pharmacogenomicsManagement.Models;
using pharmacogenomicsManagement.Services;
using pharmacogenomicsManagement.ViewModel;

namespace pharmacogenomicsManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGeneRepository _geneRepository;
        private readonly IDrugRepository _drugRepository;

        public HomeController(IGeneRepository geneRepository, IDrugRepository drugRepository)
        {
            _geneRepository = geneRepository;
            _drugRepository = drugRepository;
        }
        public IActionResult Index()
        {
            var homeVM = new HomeViewModel()
            {
                GeneCount = _geneRepository.Count(x=>true),
                DrugCount = _drugRepository.Count(x=>true)
            };
            return View(homeVM);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
