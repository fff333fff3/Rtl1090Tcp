using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace Rtl1090Tcp
{
    class Options
    {
        [Option('h', "host", Default = "localhost", HelpText = "Which hostname to listen on")]
        public string Hostname { get; set; }
        [Option('p', "port", Default = 30003, HelpText = "Which port to listen on")]
        public int Port { get; set; }
        [Option('t', "time", Default = -1, HelpText = "Auto-stop time in milliseconds (-1 to disable auto-stop)")]
        public long Time { get; set; }
    }
}
