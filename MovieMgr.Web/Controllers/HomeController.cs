using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMgr.Core.Contracts;
using MovieMgr.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMgr.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.LoadModelData(_unitOfWork);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.CategoryRepository.AddCategory(model.CategoryName);
                    _unitOfWork.Save();
                }
                catch(ValidationException ex)
                {
                    foreach (var member in ex.ValidationResult.MemberNames)
                    {
                        ModelState.AddModelError(member, ex.ValidationResult.ErrorMessage);
                    }
                }               
            }
            model.LoadModelData(_unitOfWork);
            return View(model);
        }

        public IActionResult Details(int categoryId)
        {
            HomeDetailsViewModel model = new HomeDetailsViewModel();
            model.LoadModelData(_unitOfWork,categoryId);
            return View(model);
        }

        public IActionResult Statistics()
        {
            HomeStatisticsViewModel model = new HomeStatisticsViewModel();
            model.LoadModelData(_unitOfWork);
            return View(model);
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
