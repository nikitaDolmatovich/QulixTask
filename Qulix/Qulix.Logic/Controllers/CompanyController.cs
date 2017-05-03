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

        [HttpPost]
        public ActionResult Delete(int companyId)
        {
            repo.Delete(companyId);

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Update(int companyId)
        {
            CompanyViewModel worker = CopyToViewModel(repo.GetCompanyById(companyId));

            return View(worker);
        }

        [HttpPost]
        public ActionResult Update(Company company)
        {
            if (ModelState.IsValid)
            {
                repo.Update(company.CompanyId, company);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(company);
            }
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CompanyViewModel worker)
        {
            if (!ModelState.IsValid)
            {
                repo.Add(CopyToModel(worker), GetId() + 1);
                return RedirectToAction("GetAll", "Company");
            }
            else
            {
                return View(worker);
            }     
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

        private Company CopyToModel(CompanyViewModel company)
        {
            return new Company()
            {
                CompanyId = GetId() + 1,
                Name = company.Name,
                SizeCompany = company.SizeCompany,
                OrganizationalForm = company.OrganizationalForm
            };
        }

        private int GetId()
        {
            List<CompanyViewModel> companies = new List<CompanyViewModel>();
            int count = 0;

            foreach (var company in repo.GetAll())
            {
                count++;
                companies.Add(CopyToViewModel(company));
            }

            if(count == 0)
            {
                return 0;
            }
            int id = companies.Select(x => x.CompanyId).Max();

            return id;
        }
    }
}