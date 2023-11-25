using core.Data.Repository.IRepository;
using core.Model;
using core.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace PrisonSaveSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrisonWardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrisonWardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<PrisonWard> prisonWard = _unitOfWork.PrisonWard.GetAll();
            return View(prisonWard);
        }


        [HttpGet]
        public IActionResult Crup(int? id = 0)
        {

            PrisonWardVM prisonWardVM = new()
            {
                PrisonWard = new(),
                PrisonBlockList = _unitOfWork.PrisonBlock.GetAll().Select(i => new SelectListItem
                {
                    Text = i.BlockId.ToString(),
                    Value = i.BlockId.ToString()

                })

            };

            if (id == null || id <= 0)
            {

                return View(prisonWardVM);

            }

            prisonWardVM.PrisonWard = _unitOfWork.PrisonWard.GetFirstOrDefault(i => i.PrisonWardId == id);

            if (prisonWardVM.PrisonWard==null)
            {

                return View(prisonWardVM);

            }

            return View(prisonWardVM);
        }


        [HttpPost]
        public IActionResult Crup(PrisonWardVM prisonWardVM)
        {
            if (prisonWardVM.PrisonWard.PrisonWardId <= 0)
            {

                _unitOfWork.PrisonWard.Add(prisonWardVM.PrisonWard);
                    
            }
            else
            {
                _unitOfWork.PrisonWard.Update(prisonWardVM.PrisonWard);
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

            var prisonWard = _unitOfWork.PrisonWard.GetFirstOrDefault(i => i.PrisonWardId == id);
            _unitOfWork.PrisonWard.Remove(prisonWard);
            _unitOfWork.save();
            return RedirectToAction("Index");
        }

    }
}
