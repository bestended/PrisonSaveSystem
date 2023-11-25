using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Data.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        

        ICateringCompanyRepository CateringCompany { get; }
        IGuardianRepository Guardian { get; }
        IPrisonRepository Prison { get; }
        IPrisonBlockRepository PrisonBlock { get; }
        IPrisonerRepository Prisoner { get; }
        IPrisonManagerRepository PrisonManager { get; }
        IPrisonWardRepository PrisonWard { get; }
        IVisitorRepository Visitor { get; }


        void save();


    }
}
