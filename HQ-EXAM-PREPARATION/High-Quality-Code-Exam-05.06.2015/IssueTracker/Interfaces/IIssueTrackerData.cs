namespace IssueTracker.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
    using IssueTracker.Entity.Post;
    using IssueTracker.Entity.User;

    public interface IIssueTrackerData
    {
        User CurrentUser { get; set; }

        IDictionary<string, User> UsersDictionaries { get; }

        OrderedDictionary<int, Issue> Issues1 { get; }

        MultiDictionary<string, Issue> Issues2 { get; }

        MultiDictionary<string, Issue> Issues4 { get; }

        MultiDictionary<User, Comment> Dict { get; }

        int AddIssue(Issue p);

        void RemoveIssue(Issue p);
    }
}
