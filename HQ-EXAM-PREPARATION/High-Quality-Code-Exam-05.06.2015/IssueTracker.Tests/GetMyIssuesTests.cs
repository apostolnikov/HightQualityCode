namespace IssueTracker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using System.Globalization;
    using IssueTracker.Interfaces;

    [TestClass]
    public class GetMyIssuesTests
    {
        private IIssueTracker tracker;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            tracker = new IssueTracker();
        }

        [TestMethod]
        public void Test_GetMyIssues_ShouldReturnIssuesCreatedByTheCurrentlyActiveUser()
        {
            this.tracker.RegisterUser("admin", "123", "123");
            this.tracker.LoginUser("admin", "123");
            this.tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, "[new | issue]");
            this.tracker.CreateIssue("Another issue", "This is another new issue", IssuePriority.Medium, "[another | issue | new]");

            string message = this.tracker.GetMyIssues();
            Assert.AreEqual("New issue\nPriority: ***\nThis is a new issue\nTags: issue,new" + 
                "\nAnother issue\nPriority: **\nThis is another new issue\nTags: another,issue,new", message);
            
        }

        [TestMethod]
        public void Test_GetMyIssues_ShouldReturnErrorMessageIfThereIsNoIssues()
        {
            this.tracker.RegisterUser("admin", "123", "123");
            this.tracker.LoginUser("admin", "123");
            
            string message = this.tracker.GetMyIssues();
            Assert.AreEqual("No issues", message);
        }

        [TestMethod]
        public void Test_GetMyIssues_ShouldReturnErrorMessageIfThereIsNoLoggedInUser()
        {
            this.tracker.RegisterUser("admin", "123", "123");
            this.tracker.LoginUser("admin", "123");
            this.tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, "[new | issue]");
            this.tracker.LogoutUser();

            string message = this.tracker.GetMyIssues();
            Assert.AreEqual("There is no currently logged in user", message);
        }
    }
}
