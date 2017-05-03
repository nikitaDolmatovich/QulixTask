using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qulix.Domain.Repository
{
    public interface IRepository<T> 
        where T:class
    {
        void Add(T item, int id); //Insert record to database
        void Delete(int itemId); //Delete record from database
        void Update(int itemId, T item); //Update record in database
        void Execute(string expression); //Execution of script
        IEnumerable<T> GetAll(); //Get all records
    }
}
