using MyApp.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRipository Category { get; private set; }
        public UnitofWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRipository(context);
        }
        

        public void Save()
        {
              
        }
    }
}


// generic class => model class=> unitofwork
//
//
//
//

