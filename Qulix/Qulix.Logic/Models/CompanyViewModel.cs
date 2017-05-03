using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qulix.Logic.Models
{
    public class CompanyViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int CompanyId { get; set; }

        [Display(Name ="Name")]
        [Required(ErrorMessage = "Please, enter Name")]
        public string Name { get; set; }

        [Display(Name ="Size of Company")]
        [Required(ErrorMessage = "Please, enter size of company")]
        public string SizeCompany { get; set; }

        [Display(Name = "Organizational Form ")]
        [Required(ErrorMessage = "Please, enter Organizational Form")]
        public string OrganizationalForm { get; set; }
    }
}