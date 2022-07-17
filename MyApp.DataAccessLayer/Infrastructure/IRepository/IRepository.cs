using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    // here <T> is a template class  and T is a class
    public interface IRepository <T > where T : class
    {
        IEnumerable<T> GetAll ();

        // we can't write ID here 
        // Write Expression + using Linq.Expression + add function(where function return class(T) and boolean value )
        // predicate is a class
        T GetT(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Delete(T entity);
        // IEnumerable<T> to catch multiple list or data from class
        void DeleteRange(IEnumerable<T> entity);

    }
}
