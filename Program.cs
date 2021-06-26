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

            adobeSpawnedProcessesToKill.AddRange(Process.GetProcessesByName("node"));

            adobeSpawnedProcessesToKill.AddRange(Process.GetProcessesByName("adobe update service"));
            adobeSpawnedProcessesToKill.AddRange(Process.GetProcessesByName("adobe desktop service"));

            adobeSpawnedProcessesToKill.AddRange(Process.GetProcessesByName("cclibrary"));

            adobeSpawnedProcessesToKill.AddRange(Process.GetProcessesByName("ccxprocess"));

            adobeSpawnedProcessesToKill.AddRange(Process.GetProcessesByName("coresync"));

            adobeSpawnedProcessesToKill.AddRange(Process.GetProcessesByName("creative cloud"));
            adobeSpawnedProcessesToKill.AddRange(Process.GetProcessesByName("creative cloud helper"));

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
