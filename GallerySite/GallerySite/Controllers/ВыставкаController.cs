using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GallerySite.Models;

namespace GallerySite.Controllers
{
    public class ВыставкаController : Controller
    {
        private DataBaseEntities db = new DataBaseEntities();

        // GET: Выставка
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "DateStart" ? "DateDesc" : "DateStart";
            var exhibition = from s in db.Выставка
                           select s;
            switch (sortOrder)
            {
                case "Name_desc":
                    exhibition = exhibition.OrderBy(s => s.Название_выставки); //по возрастающей
                    break;
                case "DateStart":
                    exhibition = exhibition.OrderBy(s => s.Дата_начала);
                    break;
                case "DateDesc":
                    exhibition = exhibition.OrderByDescending(s => s.Дата_начала);
                    break;
                /*default:
                    students = students.OrderBy(s => s.LastName);
                    break;*/
            }
            return View(exhibition.ToList()); //return View(db.Выставка.ToList());
        }

        // GET: Выставка/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Выставка выставка = db.Выставка.Find(id);
            if (выставка == null)
            {
                return HttpNotFound();
            }
            return View(выставка);
        }

        // GET: Выставка/Create
        public ActionResult Create()
        {
            //if (Session["Rights"].Equals("admin"))          //Работает
                return View();
            /*else 
            {
                Session.Abandon(); //Выход на всякий
                //ViewBag.Message("Авторизируйтесь для выполнения операции.");
                return View("~/Views/Home/Login.cshtml"); 
            }*/
        }

        // POST: Выставка/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Код_выставки,Название_выставки,Дата_начала,Дата_окончания")] Выставка выставка)
        {
            if (ModelState.IsValid)
            {
                db.Выставка.Add(выставка);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(выставка);
        }

        // GET: Выставка/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Выставка выставка = db.Выставка.Find(id);
            if (выставка == null)
            {
                return HttpNotFound();
            }
            return View(выставка);
        }

        // POST: Выставка/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Код_выставки,Название_выставки,Дата_начала,Дата_окончания")] Выставка выставка)
        {
            if (ModelState.IsValid)
            {
                db.Entry(выставка).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(выставка);
        }

        // GET: Выставка/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Выставка выставка = db.Выставка.Find(id);
            if (выставка == null)
            {
                return HttpNotFound();
            }
            return View(выставка);
        }

        // POST: Выставка/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Выставка выставка = db.Выставка.Find(id);
            db.Выставка.Remove(выставка);
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
