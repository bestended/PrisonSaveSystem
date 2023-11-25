using core.Data.Repository.IRepository;
using core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Data.Repository
{
    public class PrisonRepository:Repository<Prison>,IPrisonRepository
    {
      

        private AppDbContext _context;
        public PrisonRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
