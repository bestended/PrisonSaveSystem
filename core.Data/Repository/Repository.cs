using core.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace core.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly AppDbContext _context;
        internal DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }


        public void Add(T entities)
        {
            _dbSet.Add(entities);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {

            IQueryable<T> query = _dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {

                foreach (var item in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);

                }

            }
            return query.ToList();

        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {

            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);


            }

            if (includeProperties != null)
            {
                //resimleri getirmek için kullanırız.Split ayırma işlemi yapan string bir fonksiyondur
                foreach (var item in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();

        }

        public void Remove(T entities)
        {
            _dbSet.Remove(entities);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);

        }

        public void Update(T entities)
        {
            _dbSet.Update(entities);
        }
    }
}
