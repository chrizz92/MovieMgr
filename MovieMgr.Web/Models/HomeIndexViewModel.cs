using MovieMgr.Core.Contracts;
using MovieMgr.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMgr.Web.Models
{
    public class HomeIndexViewModel
    {
        public List<Category> Categories { get; set; }
        
        [Display(Name ="Kategorie"),Required(ErrorMessage ="Kategorie darf nicht leer sein!")]
        public string CategoryName { get; set; }

        public void LoadModelData(IUnitOfWork unitOfWork)
        {
            Categories = unitOfWork.CategoryRepository.GetCategories();
        }
    }
}
