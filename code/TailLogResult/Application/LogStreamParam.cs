using System;
using System.Collections.Generic;
using System.Text;

namespace TailLogResult.Application
{
    public class LogStreamParam
    {
        public string FilePath { get; set; }
        public string ExpectedLogLine { get; set; }        
        public Timeout Timeout { get; set; }
        public int LineLenght { get; set; }
        public string CommandToExecute { get; set; }

        public bool ExecuteCommand { get; set; }

    }
    public class Timeout
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }
}
