using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T: class
    {
        IList<T> GetAll(T obj);
        T Get(T obj);
        void Delete(T obj);
        void Update(T obj);        
        void Save(T obj);
        
    }
}
