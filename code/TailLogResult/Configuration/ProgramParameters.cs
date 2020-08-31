using System;
using System.Collections.Generic;
using System.Text;

namespace TailLogResult.Configuration
{
    public class ProgramParameters
    {
        public string FilePath { get; set; }
        public string ExpectedLogLine { get; set; }
        public int Timeout { get; set; }
        public string CommandToExecute { get; set; }
        public int FileLenght { get; set; }
        public bool ExecuteCommand { get; set; }
       
    }
}
