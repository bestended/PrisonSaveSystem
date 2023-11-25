using core.Data.Repository.IRepository;
using core.Model;
using core.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PrisonSaveSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VisitorController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _hostEnvironment;
        public VisitorController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;




        }
        public IActionResult Index()
        {
            var visitor = _unitOfWork.Visitor.GetAll();
            return View(visitor);
        }


        public IActionResult Crup(int? id = 0)
        {

            VisitorVM visitorVM = new()
            {
                Visitor = new(),
                PrisonerList = _unitOfWork.Prisoner.GetAll().Select(k => new SelectListItem
                {


                    Text = k.PrisonerId.ToString(),
                    Value = k.PrisonerId.ToString()


                })


            };

            if(id==null || id <= 0)
            {
                return View(visitorVM);


            }
            visitorVM.Visitor = _unitOfWork.Visitor.GetFirstOrDefault(x => x.VisitorId == id);

            if(visitorVM.Visitor == null)
            {
                return View(visitorVM);
            }
            return View(visitorVM);
        }


        [HttpPost]
        public IActionResult Crup(VisitorVM visitorVM)
        {
            if (visitorVM.Visitor.VisitorId <= 0)
            {   

                _unitOfWork.Visitor.Add(visitorVM.Visitor);
            }
            else
            {
                _unitOfWork.Visitor.Update(visitorVM.Visitor);


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


            var visitor = _unitOfWork.Visitor.GetFirstOrDefault(i => i.VisitorId == id);
            _unitOfWork.Visitor.Remove(visitor);
            _unitOfWork.save();
            return RedirectToAction("Index");
        }

    }
}
