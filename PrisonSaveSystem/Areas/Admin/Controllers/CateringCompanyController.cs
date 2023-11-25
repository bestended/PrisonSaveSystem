using core.Data.Repository.IRepository;
using core.Model;
using Microsoft.AspNetCore.Mvc;

namespace PrisonSaveSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CateringCompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;



        public CateringCompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

      

        public IActionResult Index()
        {
            IEnumerable<CateringCompany> cateringList=_unitOfWork.CateringCompany.GetAll();
            return View(cateringList);
        }

        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(CateringCompany cateringCompany)
        {
            _unitOfWork.CateringCompany.Add(cateringCompany);
            _unitOfWork.save();
            return RedirectToAction("Index");

        }


        public IActionResult Edit(int? id)
        {

            if (id==null || id<=0)
            {
                return NotFound();


            }

            var CateringCompany = _unitOfWork.CateringCompany.GetFirstOrDefault(a => a.CateringId == id);

            return View(CateringCompany);


        }



        [HttpPost]
        public IActionResult Edit(CateringCompany cateringCompany)
        {

            _unitOfWork.CateringCompany.Update(cateringCompany);
            _unitOfWork.save();
            return RedirectToAction("Index");

        }

        public  IActionResult Delete(int id)
        {
            var cateringCompany = _unitOfWork.CateringCompany.GetFirstOrDefault(a => a.CateringId == id);
            _unitOfWork.CateringCompany.Remove(cateringCompany);
            _unitOfWork.save();
            return RedirectToAction("Index");


        }


    }
}
