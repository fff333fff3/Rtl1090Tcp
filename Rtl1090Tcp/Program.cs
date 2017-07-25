﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Rtl1090Tcp
{
    class Program
    {
        static void Main(string[] args)
        {
            //SampleBytesAndSave();

            var bytes = File.ReadAllBytes("data.bin");

            var msg = bytes.Take(16).ToArray();

            var decoded = ModeS.Decode(msg);

            Console.ReadKey();
        }

        private static void SampleBytesAndSave()
        {
            var bytes = new List<byte>();
            using (var tcp = new TcpClient("localhost", 31011))
            using (var sr = new BinaryReader(tcp.GetStream()))
                while (true)
                    if (tcp.Available > 0)
                    {
                        var data = sr.ReadBytes(tcp.Available);
                        var message = string.Join(" ", data.Select(b => b.ToString("X2")));
                        bytes.AddRange(data);

                        if (bytes.Count > 1000)
                            break;
                    }

            File.WriteAllBytes("data.bin", bytes.ToArray());
        }
    }
}