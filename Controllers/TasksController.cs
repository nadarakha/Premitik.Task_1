using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Premitik.Task_1.Models;
using PagedList;

namespace Premitik.Task_1.Controllers
{
    public class TasksController : Controller
    {
        private PremitikDbContext db = new PremitikDbContext();

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index(int page = 1, int pageSize = 5, string searchText = "")
        {
            IList<Task> results;

            if (searchText != "")
            {
                results = GetBySubjectOrStatus(searchText);
            }
            else
            {
                results = db.Tasks.Include(t => t.Status).ToList();
            }

            var statusList = db.Statuses.Select(s => new SelectListItem() { Value = s.Id.ToString(), Text = s.Name });
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name");
            ViewBag.Status = db.Statuses.ToList();
            var tasks = results.OrderBy(t => t.Id).Select(t => new TaskViewModel() { Subject = t.Subject, Status = t.Status, CaseNumber = t.CaseNumber, CustomerName = t.CustomerName, Source = t.Source, ReleaseNumber = t.ReleaseNumber }).ToPagedList(page, pageSize);

            return View("_TaskTable", tasks);
        }

        public IList<Task> GetBySubjectOrStatus(string searchText)
        {
            return db.Tasks.Where(t => t.Subject.Contains(searchText) || t.Status.Name.Contains(searchText)).ToList();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var statusList = db.Statuses.Select(s => new SelectListItem() { Value = s.Id.ToString(), Text = s.Name });
            ViewBag.StatusId = new SelectList(statusList, "Value", "Text");

            return PartialView("_ModalCreate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            var statusList = db.Statuses.Select(s => new SelectListItem() { Value = s.Id.ToString(), Text = s.Name });
            ViewBag.StatusId = new SelectList(statusList, "Value", "Text");
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();

                return PartialView("_ModalCreate");

            }

            return PartialView("_ModalCreate", task);
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
