using OdeTofood.Data.Modals;
using OdeTofood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData Db;

        public RestaurantsController(IRestaurantData db)
        {
          this.Db = db;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = Db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = Db.Get(id);
            if(model == null)
            {
                return View("Notfound");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (string.IsNullOrEmpty(restaurant.Name))
            {
                ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
            }
            if(ModelState.IsValid)
            {
                Db.Add(restaurant);
                TempData["Message"] = "You have succesifully saved a restaurant!";
                return RedirectToAction("Details", new { id = restaurant.ID } );
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = Db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                Db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.ID });
            }
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = Db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            Db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}