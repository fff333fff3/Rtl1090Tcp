using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using Humanizer;

namespace Rtl1090Tcp
{
    class Program
    {
        static DateTime start = DateTime.Now;

        static void Main(string[] args)
        {
            var planes = new SimplePlaneTracker();
            var uniquePlanes = new List<string>();
            var messages = 0;
            var table = new ConsoleTable("Row", "Hex", "Callsign", "Altitude", "Lat", "Lng");
            var logTable = new ConsoleTable("Uptime", "Messages", "Planes");

            var logfile = $"{start.Ticks}.txt";

            var timer = new Timer(1000) {AutoReset = true};
            timer.Elapsed += (sender, eventArgs) =>
            {
                DrawLogTable(logTable, messages, uniquePlanes.Count);
            };
            timer.Start();

            try
            {
                using (var stream = new TcpClient("localhost", 30003))
                using (var reader = new StreamReader(stream.GetStream()))
                using (var log = new StreamWriter(logfile))
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        log.WriteLine(line);
                        planes.Consume(line);

                        uniquePlanes.AddRange(planes.Planes.Select(plane => plane.HexIdent).ToArray());
                        uniquePlanes = uniquePlanes.Distinct().ToList();

                        messages++;

                        if ((DateTime.Now - start).TotalHours >= 24)
                            break;

                        //RedrawTable(table, planes.Planes.OrderByDescending(plane => plane.Latitude == 0 ? 0 : 1).ToList());
                    }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }

            Console.WriteLine("Done.");
            Console.ReadKey();
        }

        private static void DrawLogTable(ConsoleTable logTable, int messages, int uniquePlanesCount)
        {
            Console.SetCursorPosition(0, 0);
            logTable.Rows.Clear();

            logTable.AddRow((DateTime.Now - start).Humanize(3), messages.ToMetric(false, true, 3), uniquePlanesCount);

            logTable.Write(Format.Alternative);
        }

        private static void RedrawTable(ConsoleTable table, List<TrackedPlane> planes)
        {
            Console.SetCursorPosition(0, 0);
            table.Rows.Clear();

            for (var i = 0; i < planes.Count; i++)
            {
                var trackedPlane = planes[i];
                table.AddRow(i + 1, trackedPlane.HexIdent, trackedPlane.Callsign, $"{trackedPlane.Altitude}ft", trackedPlane.Latitude,
                    trackedPlane.Longitude);

                if (i > 50)
                    break;
            }

            table.Write(Format.MarkDown);
        }
    }
}
