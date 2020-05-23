using Microsoft.AspNetCore.Mvc.Rendering;
using Philosophers_Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Philosophers_Application.ModelViews
{
    public class PhilosopherModelView
    {
        public int Id { get; set; }

        public List<SelectListItem> Countries { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Directions { get; set; } = new List<SelectListItem>();

        [Required]
        public string SelectedCountry { get; set; }

        [Required]
        public List<string> SelectedDirections { get; set; }

        [Required]
        [Display(Name = "Имя")]
        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", 
            ErrorMessage = "Невозможно добавить такое имя")]
        public string TypedName { get; set; }  
    }
}
