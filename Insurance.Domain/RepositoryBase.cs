using Insurance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Domain
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {

        private DataContext<T> Context { get; set; }

        public RepositoryBase(DataContext<T> context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));        
        }

        public void Save(T obj)
        {
            this.Context.Set(obj);
        }

        public void Delete(T obj)
        {
            this.Context.Remove(obj);
        }

        public IList<T> GetAll(T obj)
        {            
            return  this.Context.List(obj);
        }

        public T Get(T obj)
        {
            return this.Context.FirstOrDefault(obj);
        }

        public void Update(T obj)
        {
            this.Context.Update(obj);
           
        }

    }
}
