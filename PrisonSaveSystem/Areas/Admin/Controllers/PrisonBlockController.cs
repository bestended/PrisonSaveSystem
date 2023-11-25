using core.Data.Repository.IRepository;
using core.Model;
using Microsoft.AspNetCore.Mvc;

namespace PrisonSaveSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrisonBlockController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrisonBlockController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<PrisonBlock> prisonBlock = _unitOfWork.PrisonBlock.GetAll();

            return View(prisonBlock);
        }


        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(PrisonBlock prisonBlock)
        {
            _unitOfWork.PrisonBlock.Add(prisonBlock);
            _unitOfWork.save();
            return RedirectToAction("Index");

          

        }


        public IActionResult Edit(int? id)
        {
            if(id==null || id <= 0)
            {

                return NotFound();

            }

            var guardian = _unitOfWork.PrisonBlock.GetFirstOrDefault(i=>i.BlockId==id);
            return View(guardian);


        }

        [HttpPost]
        public IActionResult Edit(PrisonBlock prisonBlock)
        {
            _unitOfWork.PrisonBlock.Update(prisonBlock);
            _unitOfWork.save();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var prisonBlock = _unitOfWork.PrisonBlock.GetFirstOrDefault(i=>i.BlockId==id);
            _unitOfWork.PrisonBlock.Remove(prisonBlock);
            _unitOfWork.save();
            return RedirectToAction("Index");


        }






    }
}
