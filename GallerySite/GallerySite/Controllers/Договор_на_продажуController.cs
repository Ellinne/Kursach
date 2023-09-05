using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GallerySite.Models;
using Word = Microsoft.Office.Interop.Word;

namespace GallerySite.Controllers
{
    public class Договор_на_продажуController : Controller
    {
        private DataBaseEntities db = new DataBaseEntities();

        // GET: Договор_на_продажу
        public ActionResult Index()
        {
            var договор_на_продажу = db.Договор_на_продажу.Include(д => д.Экспонат1).Include(д => д.Клиент);
            return View(договор_на_продажу.ToList());
        }

        // GET: Договор_на_продажу/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор_на_продажу договор_на_продажу = db.Договор_на_продажу.Find(id);
            if (договор_на_продажу == null)
            {
                return HttpNotFound();
            }

            return View(договор_на_продажу);
        }

        // GET: Договор_на_продажу/Create
        public ActionResult Create()
        {
            ViewBag.Экспонат = new SelectList(db.Экспонат, "Код_экспоната", "Наименование");
            ViewBag.Покупатель = new SelectList(db.Клиент, "Код_клиента", "Фамилия");
            return View();
        }

        // POST: Договор_на_продажу/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Код_договора,Экспонат,Цена_экспоната,Покупатель,Налог,Комиссия,Доход_галереи,Гонорар")] Договор_на_продажу договор_на_продажу)
        {
            if (ModelState.IsValid)
            {
                db.Договор_на_продажу.Add(договор_на_продажу);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Экспонат = new SelectList(db.Экспонат, "Код_экспоната", "Наименование", договор_на_продажу.Экспонат);
            ViewBag.Покупатель = new SelectList(db.Клиент, "Код_клиента", "Фамилия", договор_на_продажу.Покупатель);
            return View(договор_на_продажу);
        }

        // GET: Договор_на_продажу/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор_на_продажу договор_на_продажу = db.Договор_на_продажу.Find(id);
            if (договор_на_продажу == null)
            {
                return HttpNotFound();
            }
            ViewBag.Экспонат = new SelectList(db.Экспонат, "Код_экспоната", "Наименование", договор_на_продажу.Экспонат);
            ViewBag.Покупатель = new SelectList(db.Клиент, "Код_клиента", "Фамилия", договор_на_продажу.Покупатель);
            return View(договор_на_продажу);
        }

        // POST: Договор_на_продажу/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Код_договора,Экспонат,Цена_экспоната,Покупатель,Налог,Комиссия,Доход_галереи,Гонорар")] Договор_на_продажу договор_на_продажу)
        {
            if (ModelState.IsValid)
            {
                db.Entry(договор_на_продажу).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Экспонат = new SelectList(db.Экспонат, "Код_экспоната", "Наименование", договор_на_продажу.Экспонат);
            ViewBag.Покупатель = new SelectList(db.Клиент, "Код_клиента", "Фамилия", договор_на_продажу.Покупатель);
            return View(договор_на_продажу);
        }

        // GET: Договор_на_продажу/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор_на_продажу договор_на_продажу = db.Договор_на_продажу.Find(id);
            if (договор_на_продажу == null)
            {
                return HttpNotFound();
            }
            return View(договор_на_продажу);
        }

        // POST: Договор_на_продажу/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Договор_на_продажу договор_на_продажу = db.Договор_на_продажу.Find(id);
            db.Договор_на_продажу.Remove(договор_на_продажу);
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

        public ActionResult Sale(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор_на_продажу договор_на_продажу = db.Договор_на_продажу.Find(id);
            if (договор_на_продажу == null)
            {
                return HttpNotFound();
            }
            //Договор_на_продажу договор_на_продажу = db.Договор_на_продажу.Find(id);

            if (ModelState.IsValid)
            {

                string File = @"C:\Users\petal\Downloads\Otchet.docx";
                var kok = db.Договор_на_продажу.Find(id);

                //var code = договор_на_продажу.Код_договора;
                //var code = id;
                var code = договор_на_продажу.Код_договора;
                var chislo = DateTime.Today.Date.ToShortDateString();
                var ecsponat = договор_на_продажу.Экспонат1.Наименование;
                var price = договор_на_продажу.Цена_экспоната.ToString();


                //var buyer = kok.Покупатель.ToString();
                var buyer = db.Клиент.Find(kok.Покупатель).Имя + " " + db.Клиент.Find(kok.Покупатель).Фамилия + db.Клиент.Find(kok.Покупатель).Отчество;


                var tax = kok.Налог.ToString();
                var commission = kok.Комиссия.ToString();
                var income = kok.Доход_галереи.ToString();
                var award = kok.Гонорар.ToString();

                var documentWord = new Word.Application();
                documentWord.Visible = false;
                try
                {

                    var wordDoc = documentWord.Documents.Open(File); //Open
                    ChangeInt("{code}", code, wordDoc);
                    Change("{chislo}", chislo, wordDoc);
                    Change("{ecsponat}", ecsponat, wordDoc);
                    Change("{price}", price, wordDoc);
                    Change("{buyer}", buyer, wordDoc);
                    Change("{tax}", tax, wordDoc);
                    Change("{commission}", commission, wordDoc);
                    Change("{income}", income, wordDoc);
                    Change("{award}", award, wordDoc);
                    documentWord.Visible = true;
                }
                catch
                {
                    ViewBag.Message("Ошиька бат");
                }
            }

            return RedirectToAction("Index");
        }

        private void Change(string change, string txt, Word.Document wordDoc)  //Замена строковых
        {
            var range = wordDoc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: change, ReplaceWith: txt);
        }

        private void ChangeInt(string change, int txt, Word.Document wordDoc)      //Замена на число
        {
            var range = wordDoc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: change, ReplaceWith: txt);
        }

    }
}
