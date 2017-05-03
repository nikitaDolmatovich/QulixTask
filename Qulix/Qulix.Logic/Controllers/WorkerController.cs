using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using Qulix.Domain.Repository;
using Qulix.Domain.Models;
using Qulix.Logic.Models;
using System.Text;

namespace Qulix.Logic.Controllers
{
    public class WorkerController : Controller
    {
        private WorkerRepository repo;
        private CompanyRepository companyRepo;

        public WorkerController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WorkerManager"].ConnectionString;
            repo = new WorkerRepository(connectionString);
            companyRepo = new CompanyRepository(connectionString);
        }

        public ActionResult MainPage()
        {
            return View();
        }

        public PartialViewResult GetAll()
        {
            List<WorkerViewModel> workers = new List<WorkerViewModel>();

            foreach (var worker in repo.GetAll())
            {
                string name = repo.GetNameComapnyById(worker.CompanyId);
                workers.Add(CopyToViewModel(worker,name));
            }

            return PartialView(workers);
        }

        [HttpPost]
        public ActionResult Delete(int workerId)
        {
            repo.Delete(workerId);

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Update(int workerId)
        {
            Worker workers = repo.GetWorkerById(workerId);
            string name = repo.GetNameComapnyById(workers.CompanyId);
            WorkerViewModel worker = CopyToViewModel(repo.GetWorkerById(workerId),name);

            return View(worker);
        }

        [HttpPost]
        public ActionResult Update(Worker worker)
        {
            if(ModelState.IsValid)
            {
                repo.Update(worker.WorkerId, worker);
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(worker);
            }
        }

        [HttpGet]
        public ViewResult Add()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach(var item in GetCompanies())
            {
                items.Add(new SelectListItem()
                {
                    Text = item,
                    Value = item
                });
            }
            ViewBag.Companies = items;
            return View();
        }

        [HttpPost]
        public ActionResult Add(WorkerViewModel worker)
        {
            if(!ModelState.IsValid)
            {
                string name = worker.CompanyName;
                repo.Add(CopyToModel(worker,GetComapnyId(name)),GetComapnyId(name));
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(worker);
            }
        }

        private WorkerViewModel CopyToViewModel(Worker worker,string name)
        {
            return new WorkerViewModel()
            {
                WorkerId = worker.WorkerId,
                Name = worker.Name,
                Surname = worker.Surname,
                Patronymic = worker.Patronymic,
                DateRecruitment = worker.DateRecruitment,
                Position = worker.Position,
                CompanyName = name,
                CompanyId = worker.CompanyId
            };

        }

        private Worker CopyToModel(WorkerViewModel worker, int id)
        {
            return new Worker()
            {
                WorkerId = GetId(),
                Name = worker.Name,
                Surname = worker.Surname,
                Patronymic = worker.Patronymic,
                DateRecruitment = worker.DateRecruitment,
                Position = worker.Position,
                CompanyId = id
            };

        }

        private int GetId()
        {
            List<int> companies = new List<int>();

            foreach (var item in repo.GetAll())
            {
                companies.Add(item.CompanyId);
            } 

            if(companies.Count == 0)
            {
                return 1;
            }

            return companies.Max();
        }

        public int GetComapnyId(string name)
        {
            List<Company> companies = new List<Company>();

            foreach(var item in companyRepo.GetAll())
            {
                if(item.Name == name)
                {
                    return item.CompanyId;
                }
            }

            return 0;
        }

        public List<string> GetCompanies()
        {
            List<string> companies = new List<string>();

            foreach (var item in companyRepo.GetAll())
            {
                companies.Add(item.Name);
            }

            return companies;
        }
    }
}