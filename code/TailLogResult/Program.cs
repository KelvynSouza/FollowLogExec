using System;
using System.Diagnostics;
using TailLogResult.Application;
using TailLogResult.Configuration;
using TailLogResult.Exceptions;

namespace TailLogResult
{
    class Program
    {
        static void Main(string[] args)
        {
            try
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


                logStream.Monitor();

                CommandExecuter.Execute(config.CommandToExecute);

                Console.WriteLine("Encerrado");
                
            }
            catch (TailTimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
