﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trialmanager.Models;

namespace Trialmanager.Controllers
{
    public class TrialFeasibilityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrialFeasibility
        public ActionResult Index()
        {
            var trialFeasibilityModels = db.TrialFeasibilityModels.Include(t => t.DiseaseTherapyAreaName).Include(t => t.GrantTypeName).Include(t => t.PhaseName).Include(t => t.TrialTypeName);
            return View(trialFeasibilityModels.ToList());
        }

        // GET: TrialFeasibility/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrialFeasibilityModels trialFeasibilityModels = db.TrialFeasibilityModels.Find(id);
            if (trialFeasibilityModels == null)
            {
                return HttpNotFound();
            }
            return View(trialFeasibilityModels);
        }

        // GET: TrialFeasibility/Create
        public ActionResult Create()
        {
            ViewBag.DiseaseTherapyAreaId = new SelectList(db.DiseaseTherapyAreaModels, "Id", "DiseaseTherapyAreaName");
            ViewBag.GrantTypeId = new SelectList(db.GrantTypeModels, "Id", "GrantTypeName");
            ViewBag.PhaseId = new SelectList(db.PhaseModels, "Id", "PhaseName");
            ViewBag.TrialTypeId = new SelectList(db.TrialTypeModels, "Id", "TrialTypeName");
            return View();
        }

        // POST: TrialFeasibility/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,ShortName,TrialTitle,ApplicationReference,BhNumber,TrialTypeId,Commercial,PhaseId,SampleSize,GrantTypeId,FundingStream,GrantDeadlineDate,UniConsultancyAgreement,NhsConsultancyAgreement,DiseaseTherapyAreaId")] TrialFeasibilityModels trialFeasibilityModels)
        {
            if (ModelState.IsValid)
            {
                db.TrialFeasibilityModels.Add(trialFeasibilityModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiseaseTherapyAreaId = new SelectList(db.DiseaseTherapyAreaModels, "Id", "DiseaseTherapyAreaName", trialFeasibilityModels.DiseaseTherapyAreaId);
            ViewBag.GrantTypeId = new SelectList(db.GrantTypeModels, "Id", "GrantTypeName", trialFeasibilityModels.GrantTypeId);
            ViewBag.PhaseId = new SelectList(db.PhaseModels, "Id", "PhaseName", trialFeasibilityModels.PhaseId);
            ViewBag.TrialTypeId = new SelectList(db.TrialTypeModels, "Id", "TrialTypeName", trialFeasibilityModels.TrialTypeId);
            return View(trialFeasibilityModels);
        }

        // GET: TrialFeasibility/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            TrialFeasibilityModels trialFeasibilityModels = db.TrialFeasibilityModels.Find(id);
           // TrialRecordsModels trialRecordsModels = db.TrialRecordsModels.Find(id);
            if (trialFeasibilityModels == null)
            {
                return HttpNotFound();
            }
            var contactsRole = (from c in db.TrialContactsModels
                where c.TrialId == id
                select c).ToList();
            ViewBag.contactsRole = contactsRole.Count > 0 ? contactsRole : null;

            var notes = (from c in db.NotesModels
                         where c.TrialId == id
                         select c).ToList();
            ViewBag.notifications = notes.Count > 0 ? notes : null;

            var reminders = (from r in db.TrialRemindersModels
                         where r.TrialId == id
                         select r).ToList();
            ViewBag.reminders = reminders.Count > 0 ? reminders : null;

            ViewBag.User = User.Identity.Name;
            ViewBag.Id = id;
            ViewBag.DiseaseTherapyAreaId = new SelectList(db.DiseaseTherapyAreaModels, "Id", "DiseaseTherapyAreaName", trialFeasibilityModels.DiseaseTherapyAreaId);
            ViewBag.GrantTypeId = new SelectList(db.GrantTypeModels, "Id", "GrantTypeName", trialFeasibilityModels.GrantTypeId);
            ViewBag.PhaseId = new SelectList(db.PhaseModels, "Id", "PhaseName", trialFeasibilityModels.PhaseId);
            ViewBag.TrialTypeId = new SelectList(db.TrialTypeModels, "Id", "TrialTypeName", trialFeasibilityModels.TrialTypeId);

            ViewBag.Contacts = db.ContactsModels;
            ViewBag.Roles = db.RolesModels;
            
            return View(trialFeasibilityModels);
        }

        // POST: TrialFeasibility/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,ShortName,TrialTitle,ApplicationReference,BhNumber,TrialTypeId,Commercial,PhaseId,SampleSize,GrantTypeId,FundingStream,GrantDeadlineDate,UniConsultancyAgreement,NhsConsultancyAgreement,DiseaseTherapyAreaId")] TrialFeasibilityModels trialFeasibilityModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trialFeasibilityModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiseaseTherapyAreaId = new SelectList(db.DiseaseTherapyAreaModels, "Id", "DiseaseTherapyAreaName", trialFeasibilityModels.DiseaseTherapyAreaId);
            ViewBag.GrantTypeId = new SelectList(db.GrantTypeModels, "Id", "GrantTypeName", trialFeasibilityModels.GrantTypeId);
            ViewBag.PhaseId = new SelectList(db.PhaseModels, "Id", "PhaseName", trialFeasibilityModels.PhaseId);
            ViewBag.TrialTypeId = new SelectList(db.TrialTypeModels, "Id", "TrialTypeName", trialFeasibilityModels.TrialTypeId);
            return View(trialFeasibilityModels);
        }

        [HttpPost]
        public ActionResult AjaxEdit(AjaxViewModels model)
        {
            TrialFeasibilityModels fModel = db.TrialFeasibilityModels.Find(model.Id);
            var fn = model.FieldName;
            var nv = model.NewValue;
            if (fModel != null)
            {
                var getVar = fModel.GetType().GetProperty(fn);
                if (getVar != null)
                {
                    getVar.SetValue(fModel, nv);
                }
            }
            if (ModelState.IsValid)
            {
                var record = new TrialRecordsModels
                {
                    DateTime = DateTime.Now,
                    FieldName = model.FieldName,
                    OriginalValue = model.Original,
                    NewValue = model.NewValue,
                    ReasonForChange = model.Reason,
                    TrialId = model.Id,
                    WhoChanged = User.Identity.Name
                };
                db.TrialRecordsModels.Add(record);
                db.Entry(fModel).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Edit", new {model.Id} );
        }

        public ActionResult ListAddedRecords(int? id)
        {
            var model = (from r in db.TrialRecordsModels
                where r.TrialId == id
                select r).ToList();
            return PartialView("ListRecords", model);
        }

        [HttpPost]
        public ActionResult ListContacts(TrialContactsModels model)
        {

            if (ModelState.IsValid)
            {
                var newContact = new TrialContactsModels
                {
                    ContactId = model.ContactId,
                    RoleId = model.RoleId,
                    TrialId = model.TrialId
                };
                db.TrialContactsModels.Add(newContact);
                db.SaveChanges();
            }
            return RedirectToAction("ShowUpdatedContacts", new {Id=model.TrialId});
        }

        public ActionResult ShowUpdatedContacts(int? Id)
        {
            var contactsRole = (from c in db.TrialContactsModels
                                where c.TrialId == Id
                                select c).ToList();

            ViewBag.contactsRole = contactsRole.Count > 0 ? contactsRole : null;
            ViewBag.Contacts = db.ContactsModels;
            ViewBag.Roles = db.RolesModels;
            return PartialView("_ListContacts");
        }

        [HttpPost]
        public ActionResult ListNotes(NotesModels model)
        {

            if (ModelState.IsValid)
            {
                var newNote = new NotesModels
                {
                    Who = model.Who,
                    Message = model.Message,
                    DateTime = DateTime.Now,
                    TrialId = model.TrialId
                };
                db.NotesModels.Add(newNote);
                db.SaveChanges();
            }
            return RedirectToAction("ShowUpdatedNotes", new { Id = model.TrialId });
        }

        public ActionResult ShowUpdatedNotes(int? Id)
        {
            var notes = (from c in db.NotesModels
                                where c.TrialId == Id
                                select c).ToList();
            ViewBag.notifications = notes.Count > 0 ? notes : null;
            return PartialView("_ListNotes");
        }

        [HttpPost]
        public ActionResult ListReminders(TrialRemindersModels model)
        {

            if (ModelState.IsValid)
            {
                var newReminder = new TrialRemindersModels()
                {
                    Reminder = model.Reminder,
                    DueDate = model.DueDate,
                    TrialId = model.TrialId
                };
                db.TrialRemindersModels.Add(newReminder);
                db.SaveChanges();
            }
            return RedirectToAction("ShowUpdatedReminders", new { Id = model.TrialId });
        }

        public ActionResult ShowUpdatedReminders(int? Id)
        {
            var reminders = (from c in db.TrialRemindersModels
                         where c.TrialId == Id
                         select c).ToList();
            ViewBag.reminders = reminders.Count > 0 ? reminders : null;
            return PartialView("_ListReminders");
        }
        public ActionResult ShowSetup(int? id)
        {
            TrialSetupModels trialSetupModels = db.TrialSetupModels.Find(id);
            var setupId = (from s in db.TrialSetupModels
                where s.TrialId == id
                select s).FirstOrDefault();
            if (setupId != null)
            {
                ViewBag.setupId = setupId.Id;
            }
            
            if (trialSetupModels == null)
            {
                ViewBag.Id = id;
                ViewBag.TrialLocationId = new SelectList(db.TrialLocationModels, "Id", "Location");
                ViewBag.DiseaseTherapyAreaId = new SelectList(db.DiseaseTherapyAreaModels, "Id",
                    "DiseaseTherapyAreaName");
                ViewBag.GrantTypeId = new SelectList(db.GrantTypeModels, "Id", "GrantTypeName");
                ViewBag.PhaseId = new SelectList(db.PhaseModels, "Id", "PhaseName");
                ViewBag.TrialTypeId = new SelectList(db.TrialTypeModels, "Id", "TrialTypeName");
                return PartialView("SetupNewRecord", trialSetupModels);
            }
            TrialFeasibilityModels trialFeasibilityModels = db.TrialFeasibilityModels.Find(id);
            ViewBag.TrialLocationId = new SelectList(db.TrialLocationModels, "Id", "Location", trialSetupModels.TrialLocationId);
            ViewBag.DiseaseTherapyAreaId = new SelectList(db.DiseaseTherapyAreaModels, "Id", "DiseaseTherapyAreaName", trialFeasibilityModels.DiseaseTherapyAreaId);
            ViewBag.GrantTypeId = new SelectList(db.GrantTypeModels, "Id", "GrantTypeName", trialFeasibilityModels.GrantTypeId);
            ViewBag.PhaseId = new SelectList(db.PhaseModels, "Id", "PhaseName", trialFeasibilityModels.PhaseId);
            ViewBag.TrialTypeId = new SelectList(db.TrialTypeModels, "Id", "TrialTypeName", trialFeasibilityModels.TrialTypeId);
            return PartialView("SetupEditRecord",trialSetupModels);
        }

        // GET: TrialFeasibility/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrialFeasibilityModels trialFeasibilityModels = db.TrialFeasibilityModels.Find(id);
            if (trialFeasibilityModels == null)
            {
                return HttpNotFound();
            }
            return View(trialFeasibilityModels);
        }

        // POST: TrialFeasibility/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrialFeasibilityModels trialFeasibilityModels = db.TrialFeasibilityModels.Find(id);
            db.TrialFeasibilityModels.Remove(trialFeasibilityModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
