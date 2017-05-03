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
        void Add(T item, int id);
        void Delete(int itemId);
        void Update(int itemId, T item);
        void Execute(string expression);
        IEnumerable<T> GetAll();
    }
}
