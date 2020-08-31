using System;
using System.IO;
using System.Text;
using System.Threading;
using TailLogResult.Exceptions;

namespace TailLogResult.Application
{
    class LogStream
    {
        private LogStreamParam _logStreamParameters { get; set; }

        public LogStream(LogStreamParam filepath)
        {
            _logStreamParameters = filepath;
        }

        private string TailLogLine()
        {
            using (FileStream fs = File.Open(_logStreamParameters.FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                // Seek 1024 bytes from the end of the file
                fs.Seek(Math.Max(-_logStreamParameters.FileLenght, -fs.Length), SeekOrigin.End);
                // read 1024 bytes
                byte[] bytes = new byte[_logStreamParameters.FileLenght];
                fs.Read(bytes, 0, _logStreamParameters.FileLenght);
                // Convert bytes to string
                string s = Encoding.Default.GetString(bytes).TrimEnd('\0');
                // or string s = Encoding.UTF8.GetString(bytes);
                // and output to console
                Console.Clear();
                Console.WriteLine(s);

                return s;
            }
        }

        private bool ValidateExpectedLine(string line)
        {
            return line.Contains(_logStreamParameters.ExpectedLogLine);
        }

        public void Monitor()
        {
            try
            {
                double timer = 0;
                int timeout = _logStreamParameters.GetSecondsTimeout();                
                while (timer < timeout)
                {
                    if (ValidateExpectedLine(TailLogLine())) break;

                    Thread.Sleep(100);
                    timer = timer + 0.1;
                }

                if (timer >= timeout) throw new TailTimeoutException();
            }
            catch(TailTimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
