namespace IssueTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using IssueTracker.Interfaces;

    public class Engine : IEngine
    {
        private CommandParser d;

        public Engine(CommandParser d)
        {
            this.d = d;
        }

        public Engine()
            : this(new CommandParser())
        {
        }

        public void Run()
        {
            while (true)
            {
                string url = Console.ReadLine();
                if (url != null)
                {
                    break;
                }

                url = url.Trim();

                if (string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var endPoint = new Endpoint(url); 
                        string viewResult = this.d.DispatchAction(endPoint); 
                        Console.WriteLine(viewResult);
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
