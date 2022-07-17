
using Microsoft.EntityFrameworkCore;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    // 
    public class Repository<T> : IRepository<T> where T : class
    {
        //** generic repository call data directly from DataAccess Layer  
        // access data 
        private readonly ApplicationDbContext _context;

        // access DbSet
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            //-dbSet=_context.categories     here T = cantains category 
            _dbSet =_context.Set<T>();
        }

        public void Add(T entity)
        {
            //insted of _context.Categories(); write --->
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
           _dbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }
    }
}
