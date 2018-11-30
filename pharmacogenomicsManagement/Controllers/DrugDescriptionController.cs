using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pharmacogenomicsManagement.Models;
using pharmacogenomicsManagement.Services;

namespace pharmacogenomicsManagement.Controllers
{
    public class DrugDescriptionController : Controller
    {
        private IDrugDescriptionRepository _DrugDescriptionRepository;


        public DrugDescriptionController(IDrugDescriptionRepository _IDrugDescriptionRepository)
        {
            _DrugDescriptionRepository = _IDrugDescriptionRepository;
        }

        public IActionResult Index()
        {
            return View(_DrugDescriptionRepository.GetAll());
        }
    }
}