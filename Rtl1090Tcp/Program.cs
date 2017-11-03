using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using BaseStationDotNet;
using CommandLine;

namespace Rtl1090Tcp
{
    class Program
    {
        private static DateTime _start;

        static int Main(string[] args)
        {
            _start = DateTime.Now;
            return Parser.Default.ParseArguments<Options>(args)
                .MapResult(
                    Run,
                    _ => 1);
        }

        private static int Run(Options options)
        {
            using (var stream = new TcpClient(options.Hostname, options.Port))
            using (var reader = new StreamReader(stream.GetStream()))
                while (options.Time == -1 || (DateTime.Now - _start).TotalMilliseconds < options.Time)
                {
                    if (stream.Available <= 0) continue;

                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            return 0;
        }
    }
}
