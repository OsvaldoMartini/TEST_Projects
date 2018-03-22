using System;
using System.Collections.Generic;

namespace PhoneBookTestApp.DataLayer.Utils
{
 public class GenericRepository<T> : IGenericRepository<T> where T : BaseBO
    {
        #region private Methods

        private void Validate(T entity)
        {
            if (entity is IValidation)
                entity.Validation();
        }

        #endregion


        #region Public Method IGenericRepository

        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Find(Func<T, bool> where)
        {
            var list = new List<T>();
            var obj = default(T);
            obj = Activator.CreateInstance<T>();
            list.Add(obj);

            return list;
        }
        public virtual void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        #endregion


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

