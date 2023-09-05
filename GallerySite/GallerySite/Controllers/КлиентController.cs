using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GallerySite.Models;
using Microsoft.AspNetCore.Authorization;

namespace GallerySite.Controllers
{
    public class КлиентController : Controller
    {
        private DataBaseEntities db = new DataBaseEntities();

        // GET: Клиент
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "Status";
            
            var Client = from s in db.Клиент
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Client = Client.Where(s => s.Фамилия.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Name_desc":
                    Client = Client.OrderBy(s => s.Фамилия); //по возрастающей
                    break;
                case "Status":
                    Client = Client.OrderBy(s => s.Статус);
                    break;
                    /*default:
                        students = students.OrderBy(s => s.LastName);
                        break;*/
            }
            return View(Client.ToList());
            //return View(db.Клиент.ToList());
        }

        // GET: Клиент/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Клиент клиент = db.Клиент.Find(id);
            if (клиент == null)
            {
                return HttpNotFound();
            }
            return View(клиент);
        }

        // GET: Клиент/Create

        //[System.Web.Mvc.Authorize]
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Клиент/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Код_клиента,Статус,Фамилия,Имя,Отчество,Телефон,Серия_паспорта,Номер_паспорта")] Клиент клиент)
        {
            if (ModelState.IsValid)
            {
                db.Клиент.Add(клиент);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(клиент);
        }

        // GET: Клиент/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Клиент клиент = db.Клиент.Find(id);
            if (клиент == null)
            {
                return HttpNotFound();
            }
            return View(клиент);
        }

        // POST: Клиент/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Код_клиента,Статус,Фамилия,Имя,Отчество,Телефон,Серия_паспорта,Номер_паспорта")] Клиент клиент)
        {
            if (ModelState.IsValid)
            {
                db.Entry(клиент).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(клиент);
        }

        // GET: Клиент/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Клиент клиент = db.Клиент.Find(id);
            if (клиент == null)
            {
                return HttpNotFound();
            }
            return View(клиент);
        }

        // POST: Клиент/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Клиент клиент = db.Клиент.Find(id);
            db.Клиент.Remove(клиент);
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
