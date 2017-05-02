using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Configuration;
using System.Web.Http;
using Qulix.Domain.Repository;
using Qulix.Domain.Models;

namespace Qulix.Logic.Controllers
{ 
    [RoutePrefix("Worker")]
    public class WorkerController : ApiController
    {
        private WorkerRepository repo;

        public WorkerController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WorkerManager"].ConnectionString;
            repo = new WorkerRepository(connectionString);
        }
    }
}
