using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qulix.Domain.Models
{
    public class Worker
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
