using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TailLogResult.Application;
using TailLogResult.Configuration;
using TailLogResult.Exceptions;

namespace TailLogResult
{
    class Program
    {
        static void Main(string[] args)
        {
            var ts = new Stopwatch();
            ts.Start();
            try
            {
                Console.WriteLine("Tail Log!");

                var config = ConfigurationFactory.GetParameters();

                var logParameters = new LogStreamParam()
                {
                    FilePath = config.FilePath,
                    Timeout = new Application.Timeout()
                    {
                        Hours = config.Timeout.Hours,
                        Minutes = config.Timeout.Minutes,
                        Seconds = config.Timeout.Seconds
                    },
                    ExpectedLogLine = config.ExpectedLogLine,
                    LineLenght = config.LineLenght,
                    CommandToExecute = config.CommandToExecute,
                    ExecuteCommand = config.ExecuteCommand
                    
                };

                LogStream logStream = new LogStream(logParameters);


                var task = Task.Run(async () => await logStream.Monitor());
                task.Wait();                

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ts.Stop();
                TimeSpan time = ts.Elapsed;
                Console.WriteLine($"Encerrado, Time Elapsed: {time.Hours}h {time.Minutes}m {time.Seconds}s");
            }
            Console.ReadLine();
        }
    }
}
