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
        public string Name { get; set; }

        [Display(Name="Surname")]
        public string Surname { get; set; }

        [Display(Name ="Patronymic")]
        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateRecruitment { get; set; }

        [Display(Name ="Position")]
        public string Position { get; set; }

        [Display(Name ="CompanyId")]
        public int CompanyId { get; set; }
    }
}