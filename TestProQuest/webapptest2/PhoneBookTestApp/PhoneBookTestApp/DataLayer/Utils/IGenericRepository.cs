using System;
using System.Collections.Generic;

namespace PhoneBookTestApp.DataLayer.Utils
{
 
    public interface IGenericRepository<T> : IDisposable where T : BaseBO
    {
        IEnumerable<T> GetAll();//Return all Entity data  
        IEnumerable<T> Find(Func<T, bool> where); ////Will return values often an expression
        void Add(T entity);
        void Insert(T entity);
    }
}
