using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace OdeToFood.Web.Controllers
{
    public class GreatingController : Controller
    {
        // GET: Greating
        public ActionResult Index(string name)
        {
            var modal = new GreatingViewModal();
            modal.Name = name ?? "no name";
            modal.Message = ConfigurationManager.AppSettings["message"];
            return View(modal);
        }
    }
}