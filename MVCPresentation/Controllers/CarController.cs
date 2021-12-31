using DbDomain;
using Microsoft.AspNetCore.Mvc;
using MVCPresentation.Models;

namespace MVCPresentation.Controllers
{
    public class CarController : Controller
    {
        private DataContext _dataContext = null!;
        public CarController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: CarController
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<CarViewModel> model = new List<CarViewModel>();
            model = _dataContext.Cars.Select(c => new CarViewModel
            {
                SerialNumber = c.SerialNumber,
                Model = c.Model,

            }).AsEnumerable();

            //_dataContext.Cars.Where(c => c.Id > 0).ToList();
            return View(model);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarController/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car collection)
        {
            _dataContext.Cars.Add(collection);
            _dataContext.SaveChanges();
            return RedirectToAction("Create");
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
