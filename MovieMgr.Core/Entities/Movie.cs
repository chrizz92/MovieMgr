using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MovieMgr.Core.Entities
{
    public class Movie: EntityObject
    {
        [Display(Name = "Titel"), Required(ErrorMessage ="Titel muss eingegeben werden!")]
        public string Title { get; set; }
        [ForeignKey("Category_Id")]
        public Category Category { get; set; }
        [Display(Name = "Kategorie")]
        public int Category_Id { get; set; }
        [Display(Name = "Dauer [min]"), Range(1, 1000,ErrorMessage ="Dauer muss zwischen 1 und 1000 Minuten liegen!")]
        public int Duration { get; set; } //in Minuten
        [Display(Name ="Jahr"), Range(1000, 9999,ErrorMessage ="Das Jahr muss 4-stellig sein!")]
        public int Year { get; set; }
    }
}
