namespace VehicleParkSystem
{
    using System;
    using VehicleParkSystem.Interfaces;

    public class Engine : IEngine
    {
        private Execute ex;

        public Engine(Execute ex)
        {
            this.ex = ex;
        }

        public Engine()
            : this(new Execute())
        {
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine.Trim();
                if (string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var comando = new Execute.Command(commandLine);
                        string commandResult = this.ex.execute(comando);
                        Console.WriteLine(commandResult);
                    }
                    catch (ExecutionEngineException)
                    {
                        Console.WriteLine("Invalid operation!");
                    }
                }
            }
        }
    }
}