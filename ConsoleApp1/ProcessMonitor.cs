using System;
using System.Diagnostics;
using System.Threading;

public class ProcessMonitor
{
    public static void Main(string[] args)
    {
        KillProcess(args);
    }

    public static void KillProcess(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Usage: monitor.exe process_name max_lifetime monitoring_frequency");
            return;
        }

        string processName = args[0];
        int maxLifetime = int.Parse(args[1]);
        int monitoringFrequency = int.Parse(args[2]);

        Console.WriteLine($"Monitoring process {processName} with max lifetime {maxLifetime} and frequency {monitoringFrequency}");

        while (true)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length > 0)
            {
                foreach (Process process in processes)
                {
                    if ((DateTime.Now - process.StartTime).TotalMinutes > maxLifetime)
                    {
                        Console.WriteLine($"Process {process.ProcessName} with PID {process.Id} exceeded max lifetime and will be killed.");
                        process.Kill();
                    }
                }
            }

            Thread.Sleep(monitoringFrequency * 60 * 1000);
        }
    }
}