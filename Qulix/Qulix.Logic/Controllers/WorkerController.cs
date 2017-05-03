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

        public ActionResult GetAll()
        {
            List<WorkerViewModel> workers = new List<WorkerViewModel>();

            foreach (var worker in repo.GetAll())
            {
                string name = repo.GetNameComapnyById(worker.CompanyId);
                workers.Add(CopyToViewModel(worker,name));
            }

            return View(workers);
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
                    Text = item.Name,
                    Value = item.Name
                });
            }
            ViewBag.Companies = items;
            return View(items);
        }

        [HttpPost]
        public ActionResult Add(WorkerViewModel worker)
        {
            if(ModelState.IsValid)
            {
                int id = repo.GetIdComapnyByName(worker.CompanyName);
                repo.Add(CopyToModel(worker,id),id);
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
                WorkerId = worker.WorkerId,
                Name = worker.Name,
                Surname = worker.Surname,
                Patronymic = worker.Patronymic,
                DateRecruitment = worker.DateRecruitment,
                Position = worker.Position,
                CompanyId = id
            };

        }

        public List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();

            foreach(var item in companyRepo.GetAll())
            {
                companies.Add(item);
            }

            return companies;
        }
    }
}