namespace IssueTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using IssueTracker.Interfaces;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string s)
        {
            int questionMark = s.IndexOf('?');
            if (questionMark != -1)
            {
                this.currentUsername = s.Substring(0, questionMark);

                var pairs = s.Substring(questionMark + 1).Split('&').Select(x => x.Split('=').Select(xx => WebUtility.UrlDecode(xx)).ToArray());

                var parameters = new Dictionary<string, string>();

                foreach (var pair in pairs)
                {
                    parameters.Add(pair[0], pair[1]);
                }

                this.Parameters = parameters;
            }
            else
            {
                this.CurrentUsername = s;
            }
        }

        public string CurrentUsername { get; set; }

        public IDictionary<string, string> Parameters { get; set; }
    }
}
