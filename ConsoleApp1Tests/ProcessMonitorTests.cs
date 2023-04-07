using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class PrgramMainTests
    {
        [TestMethod()]
        public void TestProcessKilling()
        {
            // Start a long-running process
            Process process = Process.Start("notepad.exe");

            // Monitor the process with max lifetime of 1 minute and monitoring frequency of 1 second
            string[] args = { "notepad", "1", "1" };
            ProcessMonitor.KillProcess(args);
            //Thread monitorThread = new Thread(() => Program.Main(args));
            //monitorThread.Start();

            // Wait for the process to be killed
            process.WaitForExit();
            //monitorThread.Abort();
        }
    }
}