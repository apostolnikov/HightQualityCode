namespace IssueTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using IssueTracker.Interfaces;
    using Wintellect.PowerCollections;

    public class IssueTrackerData : IIssueTrackerData
    {
        private int nextIssueId;

        public IssueTrackerData()
        {
            this.nextIssueId = 1;
            usersDictionary = new Dictionary<string, User>();

            this.issues = new MultiDictionary<Issue, string>(true);         
            this.issues1 = new OrderedDictionary<int, Issue>();
            this.issues2 = new MultiDictionary<string, Issue>(true);
            this.issues3 = new MultiDictionary<string, Issue>(true);

            this.dict = new MultiDictionary<User, Comment>(true);
            this.comment = new Dictionary<Comment, User>();
        }

        public User CurrentUser { get; set; }

        public IDictionary<string, User> UsersDictionary { get; set; }

        public MultiDictionary<Issue, string> Issues { get; set; }

        public OrderedDictionary<int, Issue> Issues1 { get; set; }

        public MultiDictionary<string, Issue> Issues2 { get; set; }

        public MultiDictionary<string, Issue> Issues3 { get; set; }

        public MultiDictionary<string, Issue> Issues4 { get; set; }

        public MultiDictionary<User, Comment> Dict { get; set; }

        public Dictionary<Comment, User> Comment { get; set; }

        public int AddIssue(Issue p) 
        { 
            return 0; 
        }

        public void RemoveIssue(Issue p) 
        { 
            return; 
        }
    }
}
}
