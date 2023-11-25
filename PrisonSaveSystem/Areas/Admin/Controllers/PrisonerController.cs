using core.Data.Repository.IRepository;
using core.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace PrisonSaveSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrisonerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _hostEnvironment;
        public PrisonerController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;




        }
        public IActionResult Index()
        {
            var prisonerList = _unitOfWork.Prisoner.GetAll();
            return View(prisonerList);
        }


        [HttpGet]
        public IActionResult Crup(int? id = 0)
        {
            PrisonerVM prisonerVM = new()
            {
                Prisoner = new(),
                PrisonWardList = _unitOfWork.PrisonWard.GetAll().Select(i => new SelectListItem
                {
                    Text = i.PrisonWardId.ToString(),
                    Value = i.PrisonWardId.ToString()
                   
                })


            };

            if(id==null || id <= 0)
            {

                return View(prisonerVM);


            }

            prisonerVM.Prisoner = _unitOfWork.Prisoner.GetFirstOrDefault(i => i.PrisonerId == id);

            if (prisonerVM.Prisoner == null)
            {

                return View(prisonerVM);

            }

            return View(prisonerVM);

        }


        [HttpPost]
        public IActionResult Crup(PrisonerVM prisonerVM,IFormFile file)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\prisoner");
                var extention = Path.GetExtension(file.FileName);

                if (prisonerVM.Prisoner.Picture != null)
                {
                    var oldPictPath = Path.Combine(wwwRootPath, prisonerVM.Prisoner.Picture);
                    if (System.IO.File.Exists(oldPictPath))
                    {
                        System.IO.File.Delete(oldPictPath);
                    }


                }


                using(var fileStream=new FileStream(Path.Combine(uploadRoot, fileName + extention), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    prisonerVM.Prisoner.Picture = @"\img\prisoner\" + fileName + extention;

                }



            }

            if (prisonerVM.Prisoner.PrisonerId <= 0)
            {

                _unitOfWork.Prisoner.Add(prisonerVM.Prisoner);

            }
            else
            {

                _unitOfWork.Prisoner.Update(prisonerVM.Prisoner);
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

            else
            {

                var prisoner = _unitOfWork.Prisoner.GetFirstOrDefault(i => i.PrisonerId == id);
                _unitOfWork.Prisoner.Remove(prisoner);
                _unitOfWork.save();
                return RedirectToAction("Index");


            }
        }


    }
}
