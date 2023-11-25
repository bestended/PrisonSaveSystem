using core.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public ICateringCompanyRepository CateringCompany => new CateringCompanyRepository(_context);


        //Alt kısım düzenlenecek
        public IGuardianRepository Guardian => new GuardianRepository(_context);

        public IPrisonRepository Prison => new PrisonRepository(_context);

        public IPrisonBlockRepository PrisonBlock => new PrisonBlockRepository(_context);

        public IPrisonerRepository Prisoner => new PrisonerRepository(_context);

        public IPrisonManagerRepository PrisonManager => new PrisonManagerRepository(_context);

        public IPrisonWardRepository PrisonWard => new PrisonWardRepository(_context);

        public IVisitorRepository Visitor => new VisitorRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
