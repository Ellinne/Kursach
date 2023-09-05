using ClosedXML.Excel;
using GallerySite.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GallerySite.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult О_нас()
        {
            ViewBag.Message = "Эта домашняя страница.";

            return View();
        }

        public ActionResult Каталог()
        {
            ViewBag.Message = "Your application description page.";
            //ViewBag.Images = "~/images";
            return View();
        }

        public ActionResult Сотрудничество()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Models.UsersASP model)
        {
            using (DataBaseEntities1 db = new DataBaseEntities1())
            {
                var userDetais = db.UsersASP.FirstOrDefault(x => x.name == model.name && x.password == model.password/* && x.role == model.role*/);

                if (userDetais != null)
                {
                    var userDetails = db.UsersASP.Single(x => x.name == model.name && x.password == model.password /* && x.role == model.role*/);
                    Session["UserId"] = userDetails.id;
                    Session["Rights"] = userDetails.role; // Права пользователя
                    Session["Name"] = userDetails.name;
                    ViewBag.Message1 = "Добро пожаловать, " + model.name;
                    ViewBag.Message2 = "Сменить пользователя";
                    return View("~/Views/Home/Index.cshtml"); //RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["CustomError"] = "Неверные данные";
                    ModelState.AddModelError(string.Empty, TempData["CustomError"].ToString());
                    //return RedirectToAction("Login", "Home");
                    return View("~/Views/Home/Login.cshtml");
                }
            }
        }


        public ActionResult LogOut()        //Выход из системы
        {
            Session["UserID"] = null;
            Session.Abandon();
            return View("~/Views/Home/Login.cshtml");
        }
        [HttpPost]
        public ActionResult Register(/*[Bind(Include = "Id, name, password, role")]*/ Models.UsersASP newuser)
        {
            if (ModelState.IsValid)
            {
                using (DataBaseEntities1 db = new DataBaseEntities1())
                {
                    var usernumber = db.UsersASP.Count();
                    newuser.id = usernumber + 1;        //+2
                    newuser.role = "User";
                    db.UsersASP.Add(newuser);
                    db.SaveChanges();
                    //return RedirectToAction("Index", "Home");
                }
                ModelState.Clear();
                //ViewBag.ViewBag.InsertionResult = newuser.name + " был зарегестрирован.";
                ViewBag.Message = newuser.name + " был зарегестрирован.";
            }
            ViewBag.Message = newuser.name + " был зарегестрирован.";
            return View("~/Views/Home/Reg.cshtml");
        }

       

    }

    
}