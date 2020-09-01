using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
                fs.Seek(Math.Max(-_logStreamParameters.LineLenght, -fs.Length), SeekOrigin.End);
                // read 1024 bytes
                byte[] bytes = new byte[_logStreamParameters.LineLenght];
                fs.Read(bytes, 0, _logStreamParameters.LineLenght);
                // Convert bytes to string
                string s = Encoding.Default.GetString(bytes).TrimEnd('\0');
                // or string s = Encoding.UTF8.GetString(bytes);

                // and output to console
                Console.Clear();
                Console.WriteLine(s);

                return s;
            }
        }

        public async Task Monitor()
        {
            int timeout = _logStreamParameters.Timeout.Seconds;
            var time = new TimeSpan(hours: 0, minutes: 0, seconds: timeout);
            bool monitorResult = false;

            using (var cancellationTokenSource = new CancellationTokenSource(time))
            {
                monitorResult = await MonitorLoop(cancellationTokenSource.Token);
            }

            if (_logStreamParameters.ExecuteCommand && monitorResult)
                CommandExecuter.Execute(_logStreamParameters.CommandToExecute);

        }

        private Task<bool> MonitorLoop(CancellationToken cancellationToken)
        {
            return Task.Run(new Func<bool>(() =>
            {
                try
                {
                    while (true)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            throw new TailTimeoutException();

                        if (ValidateExpectedLine(TailLogLine()))
                            return true;

                        Thread.Sleep(50);
                    }
                    
                }
                catch (TailTimeoutException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }));

        }

        private bool ValidateExpectedLine(string line)
        {
            return line.Contains(_logStreamParameters.ExpectedLogLine);
        }

        #region Old Monitor
        //public void Monitor()
        //{

        //    double timer = 0;
        //    int timeout = _logStreamParameters.GetSecondsTimeout();
        //    while (timer < timeout)
        //    {
        //        if (ValidateExpectedLine(TailLogLine())) break;

        //        Thread.Sleep(100);
        //        timer = timer + 0.1;
        //    }


        //    if (timer >= timeout) throw new TailTimeoutException();

        //}
        #endregion
    }
}
