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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int CompanyId { get; set; }

        [Display(Name ="Name")]
        public string Name { get; set; }

        [Display(Name ="SizeCompany")]
        public string SizeCompany { get; set; }

        [Display(Name = "OrganizationalForm ")]
        public string OrganizationalForm { get; set; }
    }
}