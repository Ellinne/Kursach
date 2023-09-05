using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GallerySite.Models;

namespace GallerySite.Controllers
{
    public class Договор_с_авторомController : Controller
    {
        private DataBaseEntities db = new DataBaseEntities();

        // GET: Договор_с_автором
        public ActionResult Index()
        {
            var договор_с_автором = db.Договор_с_автором.Include(д => д.Клиент).Include(д => д.Экспонат1);
            return View(договор_с_автором.ToList());
        }

        // GET: Договор_с_автором/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор_с_автором договор_с_автором = db.Договор_с_автором.Find(id);
            if (договор_с_автором == null)
            {
                return HttpNotFound();
            }
            return View(договор_с_автором);
        }

        // GET: Договор_с_автором/Create
        public ActionResult Create()
        {
            ViewBag.Автор = new SelectList(db.Клиент, "Код_клиента", "Фамилия");
            ViewBag.Экспонат = new SelectList(db.Экспонат, "Код_экспоната", "Наименование");
            return View();
        }

        // POST: Договор_с_автором/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Номер,Автор,Экспонат,Цена_оплаты_услуг")] Договор_с_автором договор_с_автором)
        {
            if (ModelState.IsValid)
            {
                db.Договор_с_автором.Add(договор_с_автором);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Автор = new SelectList(db.Клиент, "Код_клиента", "Фамилия", договор_с_автором.Автор);
            ViewBag.Экспонат = new SelectList(db.Экспонат, "Код_экспоната", "Наименование", договор_с_автором.Экспонат);
            return View(договор_с_автором);
        }

        // GET: Договор_с_автором/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор_с_автором договор_с_автором = db.Договор_с_автором.Find(id);
            if (договор_с_автором == null)
            {
                return HttpNotFound();
            }
            ViewBag.Автор = new SelectList(db.Клиент, "Код_клиента", "Фамилия", договор_с_автором.Автор);
            ViewBag.Экспонат = new SelectList(db.Экспонат, "Код_экспоната", "Наименование", договор_с_автором.Экспонат);
            return View(договор_с_автором);
        }

        // POST: Договор_с_автором/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Номер,Автор,Экспонат,Цена_оплаты_услуг")] Договор_с_автором договор_с_автором)
        {
            if (ModelState.IsValid)
            {
                db.Entry(договор_с_автором).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Автор = new SelectList(db.Клиент, "Код_клиента", "Фамилия", договор_с_автором.Автор);
            ViewBag.Экспонат = new SelectList(db.Экспонат, "Код_экспоната", "Наименование", договор_с_автором.Экспонат);
            return View(договор_с_автором);
        }

        // GET: Договор_с_автором/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор_с_автором договор_с_автором = db.Договор_с_автором.Find(id);
            if (договор_с_автором == null)
            {
                return HttpNotFound();
            }
            return View(договор_с_автором);
        }

        // POST: Договор_с_автором/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Договор_с_автором договор_с_автором = db.Договор_с_автором.Find(id);
            db.Договор_с_автором.Remove(договор_с_автором);
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
