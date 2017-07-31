using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Rtl1090Tcp
{
    class Program
    {
        static void Main(string[] args)
        {
            var planes = new SimplePlaneTracker();
            var table = new ConsoleTable("Hex", "Callsign", "Altitude", "Lat", "Lng");

            try
            {
                using (var stream = new TcpClient("localhost", 30003))
                using (var reader = new StreamReader(stream.GetStream()))
                    while (!reader.EndOfStream)
                    {
                        planes.Consume(reader.ReadLine());
                        RedrawTable(table, planes.Planes);
                    }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }

            Console.ReadKey();
        }

        private static void RedrawTable(ConsoleTable table, List<TrackedPlane> planes)
        {
            Console.SetCursorPosition(0, 0);
            table.Rows.Clear();

            for (var i = 0; i < planes.Count; i++)
            {
                var trackedPlane = planes[i];
                table.AddRow(trackedPlane.HexIdent, trackedPlane.Callsign, $"{trackedPlane.Altitude}ft", trackedPlane.Latitude,
                    trackedPlane.Longitude);

                if (i > 50)
                    break;
            }

            table.Write(Format.Minimal);
        }
    }
}
