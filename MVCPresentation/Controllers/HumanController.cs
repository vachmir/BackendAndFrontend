using DbDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPresentation.Models;
using MVCPresentation.Services;

namespace MVCPresentation.Controllers
{
    public class HumanController : Controller
    {
        private  DataContext _dataContext = null!;

        public HumanController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        // GET: HumanController
        public async Task<ActionResult> Index()
        {
            IEnumerable<HumanViewModel> model = new List<HumanViewModel>();
            model = await _dataContext.Humans.Select(h => new HumanViewModel
            {
                FirstName = h.FirstName,
                LastName = h.LastName,
                Address = h.Address,
                City = h.City,
                // CarId=h.CarId,
                Car = new CarViewModel
                {
                    Model = h.Car.Model,
                    SerialNumber = h.Car.SerialNumber,
                    Id = h.Car.Id
                },
            }).ToListAsync();
            return View(model);
        }

        // GET: HumanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HumanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HumanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Human collection)
        {
            _dataContext.Humans.Add(collection);
            _dataContext.SaveChanges();
            return RedirectToAction("Create");
        }

        // GET: HumanController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HumanController/Edit/5
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

        // GET: HumanController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HumanController/Delete/5
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
