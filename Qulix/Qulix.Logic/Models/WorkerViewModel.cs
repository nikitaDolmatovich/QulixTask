using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qulix.Logic.Models
{
    public class WorkerViewModel
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateRecruitment { get; set; }
        public string Position { get; set; }
        public int CompanyId { get; set; }
    }
}