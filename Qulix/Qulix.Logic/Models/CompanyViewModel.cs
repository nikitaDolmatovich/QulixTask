using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qulix.Logic.Models
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int SizeCompany { get; set; }
        public string OrganizationalForm { get; set; }
    }
}