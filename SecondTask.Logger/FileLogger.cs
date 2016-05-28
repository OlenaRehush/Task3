using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SecondTask.Logger
{
    public class FileLogger : ILogger
    {

        public void Info(string line)
        {
            WriteToFile(line, "Info");
        }

        public void Debug(string line)
        {
            WriteToFile(line, "Debug");
        }

        public void Warning(string line)
        {
            WriteToFile(line, "Warning");
        }

        public void Error(string line)
        {
            WriteToFile(line, "Error");
        }

        private void WriteToFile(string line, string pointer)
        {
            try
            {
                using (FileStream file = new FileStream("log.txt", FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        writer.WriteLine("{0}: {1}", pointer, line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
