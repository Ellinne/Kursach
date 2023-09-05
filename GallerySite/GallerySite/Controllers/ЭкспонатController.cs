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
    public class ЭкспонатController : Controller
    {
        private DataBaseEntities db = new DataBaseEntities();

        // GET: Экспонат
        public ActionResult Index(string sortOrder, string searchString, Models.Экспонат model)
        {
            var экспонат = db.Экспонат.Include(э => э.Выставка);
            var Exp = from s in db.Экспонат
                      select s;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "";

            if (!String.IsNullOrEmpty(searchString))
            {
                Exp = Exp.Where(s => s.Наименование.ToUpper().Contains(searchString.ToUpper()));
                using (DataBaseEntities db = new DataBaseEntities())
                {
                    var exponat = db.Экспонат.FirstOrDefault(s => s.Наименование == model.Наименование);
                    if (exponat == null)
                    {
                        ViewBag.Message4 = "Нету блат";
                        TempData["CustomError"] = "Такой записи не существует";
                        ModelState.AddModelError(string.Empty, TempData["CustomError"].ToString());
                    }
                }
                    //TempData["CustomError"] = "Такой записи не существует";
            }

            
            switch (sortOrder)
            {
                case "Name":
                    Exp = Exp.OrderBy(s => s.Наименование); //по возрастающей
                    break;
                    /*default:
                        students = students.OrderBy(s => s.LastName);
                        break;*/
            }
            return View(Exp.ToList());
            //return View(экспонат.ToList());
        }

        // GET: Экспонат/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Экспонат экспонат = db.Экспонат.Find(id);
            if (экспонат == null)
            {
                return HttpNotFound();
            }
            return View(экспонат);
        }

        // GET: Экспонат/Create
        public ActionResult Create()
        {
            ViewBag.Код_выставки = new SelectList(db.Выставка, "Код_выставки", "Название_выставки");
            return View();
        }

        // POST: Экспонат/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Код_экспоната,Вид_искусства,Наименование,Изображение,Срок_экспонирования,Статус,Код_выставки")] Экспонат экспонат)
        {
            if (ModelState.IsValid)
            {
                db.Экспонат.Add(экспонат);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Код_выставки = new SelectList(db.Выставка, "Код_выставки", "Название_выставки", экспонат.Код_выставки);
            return View(экспонат);
        }

        // GET: Экспонат/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Экспонат экспонат = db.Экспонат.Find(id);
            if (экспонат == null)
            {
                return HttpNotFound();
            }
            ViewBag.Код_выставки = new SelectList(db.Выставка, "Код_выставки", "Название_выставки", экспонат.Код_выставки);
            return View(экспонат);
        }

        // POST: Экспонат/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Код_экспоната,Вид_искусства,Наименование,Изображение,Срок_экспонирования,Статус,Код_выставки")] Экспонат экспонат)
        {
            if (ModelState.IsValid)
            {
                db.Entry(экспонат).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Код_выставки = new SelectList(db.Выставка, "Код_выставки", "Название_выставки", экспонат.Код_выставки);
            return View(экспонат);
        }

        // GET: Экспонат/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Экспонат экспонат = db.Экспонат.Find(id);
            if (экспонат == null)
            {
                return HttpNotFound();
            }
            return View(экспонат);
        }

        // POST: Экспонат/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Экспонат экспонат = db.Экспонат.Find(id);
            db.Экспонат.Remove(экспонат);
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
