using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void CorrectUpdateUserTest()
        {
            User tempUser = new User() {ID_User=4, UserType="admin", Login= "admin2@mail.ru", Password= "ytrewq!3", Name= "Дмитрий", Surname= "Александров" };
            bool excepted = true;

            bool actual = DataController.UpdateUser(tempUser);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void CorrectDeleteUserTest()
        {
            User tempUser = new User() { ID_User = 2 };
            bool excepted = true;

            bool actual = DataController.DeleteUser(tempUser);

            Assert.AreEqual(excepted, actual);
        }
    }
}
