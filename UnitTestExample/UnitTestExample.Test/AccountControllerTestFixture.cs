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
        [Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-cornunis.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool exceptedResult)
        {
            // Arrange
            var AccountController = new AccountController();

            // Act
            var ActualResult = AccountController.ValidateEmail(email);

            // Assert
            Assert.AreEqual(exceptedResult, ActualResult);
        }

        [Test,
            TestCase("Asdfjkle", false),
            TestCase("ASD1JKLE", false),
            TestCase("asd1jkle", false),
            TestCase("Asd1jkl", false),
            TestCase("Asd1jkle", true)
            ]
        public void TestValidatePassword(string password, bool exceptedResult)
        {
            //Arrage
            var AccountController = new AccountController();

            //Act
            var AccountResult = AccountController.ValidatePassword(password);

            //Assert
            Assert.AreEqual(exceptedResult, AccountResult);
        }

        [Test,
            TestCase("irf@uni-corvinus.hu", "Asdf1jkle"),
            TestCase("irf@uni-corvinus.hu", "Asdf1kle")
            ]

        public void TestRegisterHappyPath(string email, string password)
        {
            // Arrange
            var AccountController = new AccountController();

            // Act
            var AccountResult = AccountController.Register(email, password);

            //Assert
            Assert.AreEqual(email, AccountResult.Email);
            Assert.AreEqual(password, AccountResult.Password);
            Assert.AreNotEqual(Guid.Empty, AccountResult.ID);
        }
    }
}
