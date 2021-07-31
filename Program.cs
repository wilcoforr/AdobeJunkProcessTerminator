using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdobeCloudSpamProcessKiller
{
    class Program
    {
        static void Main(string[] args)
        {

            var adobeSpawnedProcessesToKill = new List<Process>();

            var processesToKill = new List<string>() 
            {
                "node"
                ,"adobe update service"
                ,"adobe desktop service"
                ,"cclibrary"
                ,"ccxprocess"
                ,"coresync"
                ,"creative cloud"
                ,"creative cloud helper" //does the above handle this PID too?
            };
            
            foreach (var process in processesToKill)
            {
                adobeSpawnedProcessesToKill.AddRange(Process.GetProcessesByName(process));
            }


            if (adobeSpawnedProcessesToKill.Any())
            {
                Console.WriteLine("Found " + adobeSpawnedProcessesToKill.Count + " Adobe processes to kill");
                foreach (var adobeProcess in adobeSpawnedProcessesToKill)
                {
                    Console.WriteLine("Killing: " + adobeProcess.ProcessName);
                    adobeProcess.Kill();
                }
            }
            else
            {
                Console.WriteLine("No Adobe spawned processes found to terminate");
            }


            Console.WriteLine("Press Enter to exit this program.");
            Console.ReadLine();
        }
    }
}
