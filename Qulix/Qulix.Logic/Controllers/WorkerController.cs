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
    public class WorkerController : Controller
    {
        private WorkerRepository repo;

        public WorkerController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WorkerManager"].ConnectionString;
            repo = new WorkerRepository(connectionString);
        }

        public ActionResult GetAll()
        {
            List<WorkerViewModel> workers = new List<WorkerViewModel>();

            foreach(var worker in repo.GetAll())
            {
                workers.Add(CopyToViewModel(worker));
            }

            return View(workers);
        }

        private WorkerViewModel CopyToViewModel(Worker worker)
        {
            return new WorkerViewModel()
            {
                WorkerId = worker.WorkerId,
                Name = worker.Name,
                Surname = worker.Surname,
                Patronymic = worker.Patronymic,
                DateRecruitment = worker.DateRecruitment,
                Position = worker.Position,
                CompanyId = worker.CompanyId
            };

        }
    }
}