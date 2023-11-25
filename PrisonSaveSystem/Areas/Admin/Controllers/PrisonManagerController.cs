using core.Data.Repository.IRepository;
using core.Model;
using core.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace PrisonSaveSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrisonManagerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrisonManagerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var prisonManager = _unitOfWork.PrisonManager.GetAll();
            return View(prisonManager);
        }


        [HttpGet]
        public IActionResult Crup(int? id=0)
        {
            PrisonManagerVM prisonManagerVM = new()
            {
                PrisonManager = new(),
                PrisonList = _unitOfWork.Prison.GetAll().Select(i => new SelectListItem
                {
                  Text=i.PrisonId.ToString(),
                  Value=i.PrisonId.ToString()



                })

            };

            if(id==null || id <= 0)
            {
                return View(prisonManagerVM);

            }

            prisonManagerVM.PrisonManager = _unitOfWork.PrisonManager.GetFirstOrDefault(i=>i.ManagerId==id);

            if (prisonManagerVM.PrisonManager == null)
            {

                return View(prisonManagerVM);


            }
            return View(prisonManagerVM);

        }

        [HttpPost]
        public IActionResult Crup(PrisonManagerVM prisonManagerVM)
        {
            if (prisonManagerVM.PrisonManager.ManagerId <= 0)
            {

                _unitOfWork.PrisonManager.Add(prisonManagerVM.PrisonManager);


            }

            else
            {
                _unitOfWork.PrisonManager.Update(prisonManagerVM.PrisonManager);
            }
            _unitOfWork.save();
            return RedirectToAction("Index");

        }





        public IActionResult Delete(int? id)
        {
            if(id==null || id <= 0)
            {
                return NotFound();


            }

            var manager = _unitOfWork.PrisonManager.GetFirstOrDefault(i => i.ManagerId == id);
            _unitOfWork.PrisonManager.Remove(manager);
            _unitOfWork.save();
            return RedirectToAction("Index");
        }

    }
}
