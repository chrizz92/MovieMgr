using Microsoft.AspNetCore.Mvc.Rendering;
using MovieMgr.Core.Contracts;
using MovieMgr.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMgr.Web.Models
{
    public class MovieCreateViewModel
    {
        public Movie Movie { get; set; }
        public SelectList Categories { get; set; }

        [Display(Name ="Kategorie")]
        public int SelectedId { get; set; }

        public void LoadModelData(IUnitOfWork uow,int categoryId)
        {
            Categories = new SelectList(uow.CategoryRepository.GetCategories(),nameof(Category.Id), nameof(Category.CategoryName));
            SelectedId = categoryId;
        }
    }
}
