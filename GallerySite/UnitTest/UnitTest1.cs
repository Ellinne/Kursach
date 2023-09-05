using System.Linq;
using System.Web.Mvc;
using GallerySite.Models;
using GallerySite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public HomeController controller;
        private ViewResult result;

        //[TestInitialize]
        public void SetupContext()
        {
            controller = new HomeController();
            result = controller.Index() as ViewResult;
        }

        [TestMethod]
        public void IndexViewResultNotNull()
        {
            // Act
            //var index = controller.Index() as ViewResult;

            // Assert   Assert.IsNotNull(index);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void HomeCheckMessage()
        {
            // Act
            var contact = controller.О_нас() as ViewResult;

            // Assert
            Assert.AreEqual("Это домашняя страница.", contact.ViewBag.Message);
        }

        [TestMethod]
        public void AboutUsNotEmpty()
        {
            // Act
            var contact = controller.О_нас() as ViewResult;

            // Assert
            Assert.IsNotNull(contact);
        }

        [TestMethod]
        public void LoginNotEmpty()
        {
            // Act
            var syslog = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(syslog);
        }

        [TestMethod]
        public void RegNotEmpty()
        {
            // Act
            var reg = controller.Reg() as ViewResult;

            // Assert
            Assert.IsNotNull(reg);
        }
    }
}
