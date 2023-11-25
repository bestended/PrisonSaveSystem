using core.Data.Repository.IRepository;
using core.Model;
using core.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace PrisonSaveSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuardianController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GuardianController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var guardian = _unitOfWork.Guardian.GetAll();
            return View(guardian);
        }

        [HttpGet]
        public IActionResult Crup(int? id=0)
        {
            GuardianVM guardianVM = new()
            {
                Guardian = new(),
                PrisonManagerList = _unitOfWork.PrisonManager.GetAll().Select(i => new SelectListItem
                {
                    Text=i.ManagerId.ToString(),
                    Value=i.ManagerId.ToString()
                }),

                PrisonBlockList=_unitOfWork.PrisonBlock.GetAll().Select(i=> new SelectListItem
                {
                    Text = i.BlockId.ToString(),
                    Value = i.BlockId.ToString()


                })



            };

            if(id==null || id <= 0)
            {

                return View(guardianVM);

            }

            guardianVM.Guardian = _unitOfWork.Guardian.GetFirstOrDefault(i=>i.GuardianId==id);

            if (guardianVM.Guardian == null)
            {

                return View(guardianVM);

            }
            return View(guardianVM);
        }


        [HttpPost]
        public IActionResult Crup(GuardianVM guardianVM)
        {

            if (guardianVM.Guardian.GuardianId <= 0)
            {

                _unitOfWork.Guardian.Add(guardianVM.Guardian);



            }

            else
            {


                _unitOfWork.Guardian.Update(guardianVM.Guardian);
            }

            _unitOfWork.save();

            return RedirectToAction("Index");



        }

      

        public IActionResult Delete(int? id)
        {
            if (id==null || id<=0)
            {
                return NotFound();



            }


            var guardian = _unitOfWork.Guardian.GetFirstOrDefault(i => i.GuardianId == id);
            _unitOfWork.Guardian.Remove(guardian);
            _unitOfWork.save();
            return RedirectToAction("Index");
        }




    }
}
