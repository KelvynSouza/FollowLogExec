using System;
using System.Diagnostics;
using TailLogResult.Application;
using TailLogResult.Configuration;

namespace TailLogResult
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tail Log!");

            var config = ConfigurationFactory.GetParameters();

            LogStream logStream = new LogStream(
                new LogStreamParam()
                {
                    FilePath = config.FilePath,
                    Timeout = config.Timeout,
                    ExpectedLogLine = config.ExpectedLogLine,
                    FileLenght = config.FileLenght
                }
                );

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            logStream.Monitor();

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            Console.WriteLine($"Elapsed Time: {ts.Hours} Hours {ts.Minutes} Minutes and {ts.Seconds} Seconds");
            Console.WriteLine("Encerrado");

            Console.ReadLine();
        }
    }
}
