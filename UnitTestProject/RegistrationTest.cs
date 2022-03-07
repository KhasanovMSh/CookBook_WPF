using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class RegistrationTest
    {
        [TestMethod]
        public void AddUserCorrectDataTest()
        {
            string tUserType="client", tLogin = "Ivanov@gmail.com", tPassword = "qwerty_1", tName="Ivan", tSurname="Petrov";
            bool excepted = true;

            bool actual = DataController.Regin(tUserType, tLogin, tPassword, tName, tSurname);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void SameLoginAddUserTest()
        {
            string tUserType = "client", tLogin = "ivanov@mail.ru", tPassword = "qwerty", tName = "Ivan", tSurname = "Petrov";
            bool excepted = false;

            bool actual = DataController.Regin(tUserType, tLogin, tPassword, tName, tSurname);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void AddUserUncorrectDataTest()
        {
            string tUserType = "client", tLogin = "login", tPassword = "qwerty", tName = "Ivan", tSurname = "Petrov";
            bool excepted = false;

            bool actual = DataController.Regin(tUserType, tLogin, tPassword, tName, tSurname);

            Assert.AreEqual(excepted, actual);
        }
    }
}
