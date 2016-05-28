using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondTask.Logger
{
    public interface ILogger
    {
        void Info(string line);
        void Debug(string line);
        void Warning(string line);
        void Error(string line);
    }
}
