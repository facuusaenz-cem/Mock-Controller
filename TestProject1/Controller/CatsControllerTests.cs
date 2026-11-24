using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mock.depart.Controllers;
using mock.depart.Services;
using Moq;

namespace TestProject1.Controller
{
    [TestClass]
    public sealed class CatsControllerTests
    {
        [TestMethod]
        public void TestDeleteCatNotFound()
        {
            Mock<CatsService> serviceMock = new Mock<CatsService>();
            Mock<CatsController> controller = new Mock<CatsController>(serviceMock.Object) { CallBase = true };

            serviceMock.Setup(s => s.Get(It.IsAny<int>())).Returns(value: null);
            controller.Setup(c => c.UserId).Returns("1");

            var actionResult = controller.Object.DeleteCat(0);
            var result = actionResult.Result as NotFoundResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestNotTheOwnerOfLeChat()
        {

        }

    }
}
