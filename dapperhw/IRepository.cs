using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Scripts
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T item);
        void Delete(Guid id);
        List<T> GetAll();
    }
}
