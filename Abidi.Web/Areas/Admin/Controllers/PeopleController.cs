﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Abidi.DataLayer.Context;
using Abidi.DataLayer.Models;
using Abidi.DataLayer.Repositories;
using Abidi.DataLayer.Services;
using OfficeOpenXml;
using Rotativa;

namespace Abidi.Web.Areas.Admin.Controllers
{
    public class PeopleController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        [Authorize]
        // GET: Admin/People
        public ActionResult Index()
        {
            return View(db.PersonRepository.Get());
        }

        // GET: Admin/People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person person = db.PersonRepository.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Admin/People/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,PersonalCode,NationalCode,InsertUser,InsertDate,UpdateUser,UpdateDate,IsDeleted")] Person person)
        {
            if (ModelState.IsValid)
            {
                if (db.PersonRepository.IsExistPerson(person.PersonalCode, person.NationalCode))
                {
                    db.PersonRepository.Insert(person);
                    db.PersonRepository.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("PersonalCode", "این کد پرسنلی تکراری است");
                    ModelState.AddModelError("NationalCode", "این کد ملی تکراری است");
                }

            }

            return PartialView(person);
        }

        // GET: Admin/People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person person = db.PersonRepository.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Admin/People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PersonalCode,NationalCode,InsertUser,InsertDate,UpdateUser,UpdateDate,IsDeleted")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.PersonRepository.Update(person);
                db.PersonRepository.Save();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Admin/People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.PersonRepository.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Admin/People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            db.PersonRepository.Delete(id);
            db.PersonRepository.Save();
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

        //public ActionResult ExportToExcel()
        //{
        //    var data = db.People.ToList();

        //    GridView gridView = new GridView();
        //    gridView.DataSource = data;
        //    gridView.DataBind();


        //    Response.ClearContent();
        //    Response.Buffer = true;

        //    Response.AddHeader("content-disposition", "attachment;filename = People.xls");
        //    Response.ContentType = "application/ms-excel";
        //    Response.Charset = "";

        //    using (StringWriter sw = new StringWriter())
        //    {
        //        using (HtmlTextWriter htw = new HtmlTextWriter(sw))
        //        {
        //            gridView.RenderControl(htw);
        //            Response.Output.Write(sw.ToString());
        //            Response.Flush();
        //            Response.End();
        //        }
        //    }

        //    return View();
        //}

        //public ActionResult Excel()
        //{
        //    var data = db.People.ToList();

        //    ExcelPackage excel = new ExcelPackage();
        //    var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
        //    workSheet.Cells[1, 1].LoadFromCollection(data, true);
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        //here i have set filname as Students.xlsx
        //        Response.AddHeader("content-disposition", "attachment;  filename=Users.xlsx");
        //        excel.SaveAs(memoryStream);
        //        memoryStream.WriteTo(Response.OutputStream);
        //        Response.Flush();
        //        Response.End();
        //    }

        //    return View();
        //}

        public ActionResult PdfOutput()
        {
            var person = db.PersonRepository.Get();

            var etp = new PartialViewAsPdf("_PartialPdf", person);/*{ FileName="Users.pdf"}*/

            return etp;
        }

        public ActionResult ExcelOutput()
        {
            string filename = "People";
            List<Person> userlist = (List<Person>)db.PersonRepository.Get();
            GridView gv = new GridView();
            gv.DataSource = userlist;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + filename + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return View("index");
        }

    }
}
