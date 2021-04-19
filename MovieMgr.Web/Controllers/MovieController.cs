using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMgr.Core.Contracts;
using MovieMgr.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMgr.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public MovieController(ILogger<MovieController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Create(int categoryId)
        {
            MovieCreateViewModel model = new MovieCreateViewModel();
            model.LoadModelData(_unitOfWork, categoryId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Movie.Category_Id = model.SelectedId;
                    _unitOfWork.MovieRepository.AddMovie(model.Movie);
                    _unitOfWork.Save();
                    return RedirectToAction("Details", "Home", new { categoryId = model.Movie.Category_Id });
                }
                catch (ValidationException ex)
                {
                    foreach (var member in ex.ValidationResult.MemberNames)
                    {
                        ModelState.AddModelError(member,ex.ValidationResult.ErrorMessage);
                    }         
                }                
            }
            model.LoadModelData(_unitOfWork, model.Movie.Category_Id);
            return View(model);
        }

        public IActionResult Delete(int movieId)
        {
            MovieDeleteViewModel model = new MovieDeleteViewModel();
            model.LoadModelData(_unitOfWork, movieId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(MovieDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.MovieRepository.DeleteMovie(model.MovieId);
                    _unitOfWork.Save();
                    return RedirectToAction("Details","Home",new {categoryId = model.CategoryId});
                }
                catch(ValidationException ex)
                {
                    foreach (var member in ex.ValidationResult.MemberNames)
                    {
                        ModelState.AddModelError(member, ex.ValidationResult.ErrorMessage);
                    }             
                }
                
            }
            model.LoadModelData(_unitOfWork,model.Movie.Id);
            return View(model);
        }
    }
}
