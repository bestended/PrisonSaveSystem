using core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
                

        }

        public DbSet<CateringCompany> CateringCompanies { get; set; }
        public DbSet<Prison> Prisons { get; set; }
        public DbSet<PrisonManager> PrisonManagers { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<PrisonBlock> PrisonBlocks { get; set; }
        public DbSet<PrisonWard> PrisonWards { get; set; }
        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<Visitor> Visitors { get; set; }





    }
}
