namespace IssueTracker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using System.Globalization;
    using IssueTracker.Interfaces;

    [TestClass]
    public class SearchForIssuesTests
    {
        private IIssueTracker tracker;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            tracker = new IssueTracker();
        }

        [TestMethod]
        public void Test_SearchForIssues_ShouldFindIssuesByGivenTag()
        {
            this.tracker.RegisterUser("admin", "123", "123");
            this.tracker.LoginUser("admin", "123");
            this.tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, "[new | issue]");
            this.tracker.CreateIssue("Another issue", "This is another new issue", IssuePriority.Medium, "[another | issue | new]");

            string message = this.tracker.SearchForIssues(["new"]);
            Assert.AreEqual("New issue\nPriority: ***\nThis is a new issue\nTags: issue,new" + 
                "\nAnother issue\nPriority: **\nThis is another new issue\nTags: another,issue,new", message);
        }

        [TestMethod]
        public void Test_SearchForIssues_ShouldReturnErrorMessageIfThereIsNoTagsProvided()
        {
            this.tracker.RegisterUser("admin", "123", "123");
            this.tracker.LoginUser("admin", "123");
            this.tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, "[new | issue]");
            this.tracker.CreateIssue("Another issue", "This is another new issue", IssuePriority.Medium, "[another | issue | new]");

            string message = this.tracker.SearchForIssues([""]);
            Assert.AreEqual("There are no tags provided", message);
        }

        [TestMethod]
        public void Test_SearchForIssues_ShouldReturnErrorMessageThereAreNoMatchingIssues()
        {
            this.tracker.RegisterUser("admin", "123", "123");
            this.tracker.LoginUser("admin", "123");
            this.tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, "[new | issue]");
            this.tracker.CreateIssue("Another issue", "This is another new issue", IssuePriority.Medium, "[another | issue | new]");

            string message = this.tracker.SearchForIssues(["pesho", "gosho"]);
            Assert.AreEqual("There are no issues matching the tags provided", message);
        }
        
    }
}
