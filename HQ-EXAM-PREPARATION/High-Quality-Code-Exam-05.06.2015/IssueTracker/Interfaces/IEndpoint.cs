namespace IssueTracker.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IEndpoint
    {
        string CurrentUsername { get; } 

        IDictionary<string, string> Parameters { get; }
    }
}
