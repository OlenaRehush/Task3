using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondTask.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Info(string line)
        {
            Console.WriteLine("Info: {0}", line);
        }

        public void Debug(string line)
        {
            Console.WriteLine("Debug: {0}", line);
        }

        public void Warning(string line)
        {
            Console.WriteLine("Warning: {0}", line);
        }

        public void Error(string line)
        {
            Console.WriteLine("Error: {0}", line);
        }
    }
}
