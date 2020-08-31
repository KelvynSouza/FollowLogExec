using System;
using System.Collections.Generic;
using System.Text;

namespace TailLogResult.Application
{
    class LogStreamParam
    {
        public string FilePath { get; set; }
        public string ExpectedLogLine { get; set; }
        public int Timeout { get; set; }
        public int FileLenght { get; set; }
        public string CommandToExecute { get; set; }

        public int GetSecondsTimeout()
        {
            return Timeout * 60;
        }
    }
}
