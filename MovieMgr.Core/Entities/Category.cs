using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MovieMgr.Core.Entities
{
    public class Category: EntityObject
    {
        [Required(ErrorMessage ="Bezeichnung darf nicht leer sein!")]
        public string CategoryName { get; set; }
    }
}
