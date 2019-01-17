using System;
using System.Diagnostics;

namespace Core 
{
    class Program 
    {
        static void Main (string[] args)
        {
            const String ListCommand = "-c ls";

            Console.Write("Enter a path to get a list of its files: ");
            String path = Console.ReadLine();
            Console.WriteLine(String.Format("Command to be executed on bash: {0} {1}", ListCommand, path));

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    WorkingDirectory = @path,
                    Arguments = ListCommand,
                    FileName = "/bin/bash",
                    RedirectStandardOutput = true
                }
            };
            process.Start();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            process.WaitForExit();
        }
    }
}