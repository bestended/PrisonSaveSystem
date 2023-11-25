using core.Data.Repository.IRepository;
using core.Model;
using core.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace PrisonSaveSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrisonController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrisonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
           var  prisonList = _unitOfWork.Prison.GetAll();
            return View(prisonList);
        }


        [HttpGet]
        public IActionResult Crup(int? id=0)
        {
            PrisonVM prisonVM = new()
            {
                Prison = new(),
                CateringCompaniesList = _unitOfWork.CateringCompany.GetAll().Select(i => new SelectListItem
                {
                    Text=i.CateringId.ToString(),
                    Value=i.CateringId.ToString()

                })


            };

            if(id==null || id <= 0)
            {



                return View(prisonVM);

            }

            prisonVM.Prison = _unitOfWork.Prison.GetFirstOrDefault(i => i.PrisonId == id);

            if (prisonVM.Prison == null)
            {

                return View(prisonVM);

            }
            return View(prisonVM);

        }


        [HttpPost]
        public IActionResult Crup(PrisonVM prisonVM)
        {
            if (prisonVM.Prison.PrisonId <=0)
            {

                _unitOfWork.Prison.Add(prisonVM.Prison);



            }
            else
            {
                _unitOfWork.Prison.Update(prisonVM.Prison);
            }
            _unitOfWork.save();
            return RedirectToAction("Index");


        }

        public IActionResult Delete(int id)
        {
            if (id == null || id <= 0)
            {

                return NotFound();
            }
            var prison = _unitOfWork.Prison.GetFirstOrDefault(i => i.PrisonId == id);
            _unitOfWork.Prison.Remove(prison);
            _unitOfWork.save();
            return RedirectToAction("Index");
        }



    }
}
