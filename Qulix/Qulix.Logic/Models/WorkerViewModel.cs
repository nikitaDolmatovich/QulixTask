using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Qulix.Logic.Models
{
    public class WorkerViewModel
    {
        [HiddenInput(DisplayValue =false)]
        public int WorkerId { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage = "Please, enter Name")]
        public string Name { get; set; }

        [Display(Name="Surname")]
        [Required(ErrorMessage = "Please, enter Surname")]
        public string Surname { get; set; }

        [Display(Name ="Patronymic")]
        [Required(ErrorMessage = "Please, enter Patronymic")]
        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Please, enter Date")]
        public DateTime DateRecruitment { get; set; }

        [Display(Name ="Position")]
        [Required(ErrorMessage = "Please, enter Position")]
        public string Position { get; set; }

        [Display(Name ="Name of Company")]
        [Required(ErrorMessage = "Please, enter Name of Company")]
        public string CompanyName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CompanyId { get; set; }

    }
}