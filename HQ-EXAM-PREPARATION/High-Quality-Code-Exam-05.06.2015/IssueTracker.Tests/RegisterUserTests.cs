namespace IssueTracker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using System.Globalization;
    using IssueTracker.Interfaces;

    [TestClass]
    public class RegisterUserTests
    {
        private IIssueTracker tracker;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            tracker = new IssueTracker();
        }

        [TestMethod]
        public void Test_RegisterUser_ShouldRegisterUserSuccessfuly()
        {
            string message = this.tracker.RegisterUser("admin", "123", "123");
            Assert.AreEqual("User admin registered successfully", message);
        }

        [TestMethod]
        public void Test_RegisterUser_ShouldReturnErrorMessageIfAnUserIsAlreadyLogedOn()
        {
            this.tracker.RegisterUser("admin", "123", "123");
            this.tracker.LoginUser("admin", "123");
            string message = this.tracker.RegisterUser("ivan", "123", "123");
            Assert.AreEqual("There is already a logged in user", message);
        }

        [TestMethod]
        public void Test_RegisterUser_ShouldReturnErrorMessageIfTheProvidedPasswordsDontMatch()
        {
            string message = this.tracker.RegisterUser("admin", "123", "456");
            Assert.AreEqual("The provided passwords do not match", message);
        }

        [TestMethod]
        public void Test_RegisterUser_ShouldReturnErrorMessageIfTheUsernameIsAlreadyTaken()
        {
            this.tracker.RegisterUser("admin", "123", "123");
            string message = this.tracker.RegisterUser("admin", "555", "555");
            Assert.AreEqual("A user with username admin already exists", message);
        }
    }
}
