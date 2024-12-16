using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Models.Repositories.Abstractions
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Edit<T>(T entity);
        T Get(object id);
        void Delete(object id);
        void SaveChanges();
    }
}
