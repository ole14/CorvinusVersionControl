using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [Test]
        public void TestValidateEmail(string email, bool exceptedResult)
        {
            // Arrange
            var AccountController = new AccountController();

            // Act
            var ActualResult = AccountController.ValidateEmail(email);

            // Assert
            Assert.AreEqual(exceptedResult, ActualResult);
        }
    }
}
