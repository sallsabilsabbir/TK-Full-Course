using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;

namespace ASP.NETCORE6.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        
        /* private readonly ApplicationDbContext _context;
         public CategoryController(ApplicationDbContext context)
         {
             _context = context;
         }*/

        private IUnitofWork _unitofWork;

        public CategoryController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _unitofWork.Category.GetAll();
            return View(categories);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Category.Add(category);
                _unitofWork.Save();

                TempData["success"] = "Created done Successfuly!";

                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitofWork.Category.GetT(x => x.id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Category.Update(category);
                _unitofWork.Save();

                TempData["success"] = "Updateed Done Successfuly!";


                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitofWork.Category.GetT(x => x.id == id); ;
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _unitofWork.Category.GetT(x => x.id == id); ;
            _unitofWork.Category.Delete(category);
            _unitofWork.Save();

            TempData["success"] = "Delete Done Successfuly!";


            return RedirectToAction("Index");
        }
    }
}
