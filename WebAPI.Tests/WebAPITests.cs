using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebAPI.Domain.Entities;
using System.Web.Http;
using System.Linq;

namespace WebAPI.Tests
{
    [TestClass]
    public class WebAPITests
    {
        [TestMethod]
        public void TryGetExist()
        {
            var testUserController = new WebAPI.Controllers.UserController();
            var userFromController = testUserController.Get();
            Assert.IsNotNull(userFromController);
        }

        [TestMethod]
        public void TryGet1Recover()
        {
            var testUserController = new WebAPI.Controllers.UserController();
            var userFromController = testUserController.Get(1);
            Assert.AreEqual(userFromController.Id, 1);
        }

        [TestMethod]
        public void TryCreate()
        {
            var testUserController = new WebAPI.Controllers.UserController();
            var name = Guid.NewGuid().ToString();
            var userFromController = testUserController.Post(new User {
                Name = name,
                Birthdate = DateTime.Now
            });
            Assert.AreEqual(userFromController.Name, name);
        }

        [TestMethod]
        public void TryEdit()
        {
            var testUserController = new WebAPI.Controllers.UserController();
            var lastUser = testUserController.Get().Last();
            var newName = Guid.NewGuid().ToString();
            var userFromController = testUserController.Put(
                lastUser.Id,
                new User
                {
                    Name = newName,
                    Birthdate = lastUser.Birthdate
                });

            Assert.AreEqual(userFromController, 1);

            var testUser = testUserController.Get(lastUser.Id);

            Assert.AreEqual(testUser.Name, newName);
        }

        [TestMethod]
        public void TryDelete()
        {
            var testUserController = new WebAPI.Controllers.UserController();
            int lastUserId = testUserController.Get().Last().Id;

            var userFromController = testUserController.Delete(lastUserId);

            Assert.AreEqual(userFromController, 1);


            var testUser = testUserController.Get(lastUserId);

            Assert.IsNull(testUser);
        }
    }
}
