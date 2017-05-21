namespace IssueTracker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using System.Globalization;
    using IssueTracker.Interfaces;
    using IssueTracker.Utilities;

    [TestClass]
    public class CreateIssueTests
    {
        private IIssueTracker tracker; 

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            tracker = new IssueTracker();                
        }

        [TestMethod]
        public void Test_CreateIssue_ShouldCreateIssueSucceffuly()
        {
            this.tracker.RegisterUser("admin", "123", "123");
            this.tracker.LoginUser("admin", "123");

            string message = this.tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, "[new | issue]");
            Assert.AreEqual("Issue 1 created successfully", message);
        }

        [TestMethod]
        public void Test_CreateIssue_ShouldReturnErrorMessageIfThereIsNoLoggedInUser()
        {
            this.tracker.RegisterUser("admin", "123", "123");

            string message = this.tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, "[new | issue]");
            Assert.AreEqual("There is no currently logged in user", message);
        }

        [TestMethod]
        public void Test_CreateIssue_ShouldThrowsArgumentExceptionIfTheTitleIsLessThanThreeSimbols()
        {
            this.tracker.RegisterUser("admin", "123", "123");
            this.tracker.LoginUser("admin", "123");

            ArgumentException ex = this.tracker.CreateIssue("Ne", "This is a new issue", IssuePriority.High, "[new | issue]");
            Assert.AreEqual(ArgumentException, ex);
        }

        [TestMethod]
        public void Test_CreateIssue_ShouldThrowsArgumentExceptionIfTheDescriptionIsLessThanFiveSimbols()
        {
            this.tracker.RegisterUser("admin", "123", "123");
            this.tracker.LoginUser("admin", "123");

            ArgumentException ex = this.tracker.CreateIssue("New issue", "This", IssuePriority.High, "[new | issue]");
            Assert.AreEqual(ArgumentException, ex);
        }
        
    }
}
