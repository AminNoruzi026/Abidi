using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Abidi.DataLayer.Context;
using Abidi.DataLayer.Models;

namespace Abidi.Web.Areas.Admin.Controllers
{
    public class PersonFilesController : Controller
    {
        private AbidiContext db = new AbidiContext();

        // GET: Admin/PersonFiles
        public ActionResult Index(int? id)
        {
            var personFiles = db.PersonFiles.Include(u => u.Person);
            return View(personFiles.Where(u => u.PersonId == id).ToList());
        }

        // GET: Admin/PersonFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonFile personFile = db.PersonFiles.Find(id);
            if (personFile == null)
            {
                return HttpNotFound();
            }
            return View(personFile);
        }

        // GET: Admin/PersonFiles/Create
        public ActionResult Create(int id)
        {
            ViewBag.PersonId = new SelectList(db.People.Where(u => u.Id == id), "Id", "FirstName");
            //..........این کد نمایش لیست کاربران در DropDownList
            return View();
        }

        // POST: Admin/PersonFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FileId,PersonId,FileName,FileFormat,FileAddress")] PersonFile personFile, HttpPostedFileBase[] FileAddress)
        {
            if (ModelState.IsValid)
            {
                foreach (HttpPostedFileBase file in FileAddress)
                {
                    if (file != null)
                    {
                        personFile.FileName = Path.GetFileName(file.FileName);
                        personFile.FileFormat = Path.GetExtension(Path.GetFileName(file.FileName));

                        var InputFileName = Guid.NewGuid() + Path.GetExtension(Path.GetFileName(file.FileName));
                        var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + InputFileName);
                        file.SaveAs(ServerSavePath);

                        personFile.FileAddress = "~/UploadedFiles/" + InputFileName;
                        //......در این بخش نام محل ذخیره عکس دریافت می شود

                        db.PersonFiles.Add(personFile);
                        db.SaveChanges();
                        ViewBag.UploadStatus = FileAddress.Count().ToString() + " با موفقیت آپلود شد";
                    }

                }

                return RedirectToAction("Index", "People");
            }

            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", personFile.PersonId);
            return View(personFile);
        }

        // GET: Admin/PersonFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonFile personFile = db.PersonFiles.Find(id);
            if (personFile == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", personFile.PersonId);
            return View(personFile);
        }

        // POST: Admin/PersonFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FileId,PersonId,FileName,FileFormat,FileAddress")] PersonFile personFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", personFile.PersonId);
            return View(personFile);
        }

        // GET: Admin/PersonFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonFile personFile = db.PersonFiles.Find(id);
            if (personFile == null)
            {
                return HttpNotFound();
            }
            return View(personFile);
        }

        // POST: Admin/PersonFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonFile personFile = db.PersonFiles.Find(id);
            db.PersonFiles.Remove(personFile);
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

        public ActionResult DownloadFile(int id)
        {
            var filePerson = db.PersonFiles.Find(id);
            Session["FileAddress"] = filePerson.FileAddress.FirstOrDefault();
            return RedirectToAction("Index");
        }
    }
}
