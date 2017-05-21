namespace IssueTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using IssueTracker.Interfaces;
    using IssueTracker.Utilities;

    public class CommandParser
    {
        private IssueTracker tracker;

        public CommandParser(IssueTracker tracker)
        {
            this.Tracker = tracker;
        }
        
        public IIssueTracker Tracker { get; set; }

        public string DispatchAction(Endpoint endpoint)
        {
            switch (endpoint.aktionname)
            {
                case "RegisterUser":
                    return this.Tracker.RegisterUser(endpoint.parametern["username"], endpoint.parametern["password"], endpoint.parametern["confirmPassword"]);
                case "LoginUser":
                    return this.Tracker.LoginUser(endpoint.parametern["username"], endpoint.parametern["password"]);
                case "CreateIssue":
                    return this.Tracker.CreateIssue(endpoint.parametern["title"], 
                        endpoint.parametern["description"],
                        (IssuePriority)System.Enum.Parse(typeof(IssuePriority), endpoint.parametern["priority"], true),
                        endpoint.parametern["tags"].Split('/'));
                case "RemoveIssue":
                    return this.Tracker.RemoveIssue(int.Parse(endpoint.parametern["id"]));
                case "AddComment":
                    return this.Tracker.AddComment(
                        int.Parse(endpoint.parametern["Id"]),
                        endpoint.parametern["text"]);
                case "MyIssues": 
                    return this.Tracker.GetMyIssues();
                case "MyComments": 
                    return this.Tracker.GetMyComments();
                case "Search":
                    return this.Tracker.SearchForIssues(endpoint.parametern["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", endpoint.aktionname);
            }
        }
    }
}
