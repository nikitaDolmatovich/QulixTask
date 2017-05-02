using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using Qulix.Domain.Repository;
using Qulix.Domain.Models;
using Qulix.Logic.Models;

namespace Qulix.Logic.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyRepository repo;

        public CompanyController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WorkerManager"].ConnectionString;
            repo = new CompanyRepository(connectionString);
        }

        public ActionResult GetAll()
        {
            List<CompanyViewModel> companies = new List<CompanyViewModel>();

            foreach (var company in repo.GetAll())
            {
                companies.Add(CopyToViewModel(company));
            }

            return View(companies);
        }

        private CompanyViewModel CopyToViewModel(Company company)
        {
            return new CompanyViewModel()
            {
                CompanyId = company.CompanyId,
                Name = company.Name,
                SizeCompany = company.SizeCompany,
                OrganizationalForm = company.OrganizationalForm
            };
        }
    }
}