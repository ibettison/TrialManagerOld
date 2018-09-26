using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trialmanager.Models;

namespace Trialmanager.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.Feasibility = 5;
            ViewBag.Live = 4;
            ViewBag.Closed = 0;
            ViewBag.Late = 5;
            var trialFeasibilityModels = db.TrialFeasibilityModels.Include(t => t.DiseaseTherapyAreaName).Include(t => t.GrantTypeName).Include(t => t.PhaseName).Include(t => t.TrialTypeName);
            return View(trialFeasibilityModels.ToList());
        }
        [Authorize(Roles="CRF-TrialManager_Database")]
        public ActionResult Edit(int? id)
        {
            return RedirectToAction("Edit","TrialFeasibility", new {@id=id});
        }
    }
}