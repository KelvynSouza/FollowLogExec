using System;
using System.Collections.Generic;
using System.Text;

namespace TailLogResult.Application
{
    public static class CommandExecuter
    {
        public static void Execute(string command)
        {
            var process = new System.Diagnostics.Process();
            var startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/C {command}";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
          
        }
    }
}
