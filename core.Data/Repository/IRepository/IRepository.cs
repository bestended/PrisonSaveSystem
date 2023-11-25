using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace core.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        void Add(T entities);
        void Update(T entities);
        void Remove(T entities);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);

        void RemoveRange(IEnumerable<T> entities);
        IEnumerable<T> GetAll(Expression<Func<T,bool>>? filter=null,string? includeProperties=null);


    }
}
