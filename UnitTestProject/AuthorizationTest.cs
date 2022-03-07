using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class AuthorizationTest
    {
        [TestMethod]
        public void CorrectDataTest()
        {
            string tLogin = "admin@mail.ru", tPassword = "qwerty";
            bool excepted = true;

            bool actual = DataController.Login(tLogin, tPassword);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void UncorrectDataTest()
        {
            string tLogin = "admin@mail.ru", tPassword = "qwerty1";
            bool excepted = false;

            bool actual = DataController.Login(tLogin, tPassword);

            Assert.AreEqual(excepted, actual);
        }
    }
}
