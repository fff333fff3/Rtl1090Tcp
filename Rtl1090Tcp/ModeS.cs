using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtl1090Tcp
{
    class ModeS
    {
        public static TelemetryMessage Decode(byte[] bytes)
        {
            using (var mem = new MemoryStream(bytes))
            using (var br = new BinaryReader(mem))
            {
                var escape = br.ReadByte();
                if (escape != 0x1A)
                    throw new Exception();

                var type = br.ReadByte();
                
                var time = br.ReadBytes(6);

                switch (type)
                {
                    case 0x31:
                        return DecodeModeAC(br);
                    case 0x32:
                        return DecodeShortModeS(br);
                    case 0x33:
                        return DecodeLongModeS(br);
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        private static TelemetryMessage DecodeLongModeS(BinaryReader br)
        {
            throw new NotImplementedException();
        }

        private static TelemetryMessage DecodeShortModeS(BinaryReader br)
        {
            var dfCa = br.ReadByte();
            var downlinkFormat = (dfCa & 0b11111000) >> 3;
            var capability = (dfCa & 0b00000111);

            var icao = br.ReadBytes(3);
            var aircraftAddress = (icao[0] << 16) + (icao[1] << 8) + icao[2];

            return null;
        }

        private static TelemetryMessage DecodeModeAC(BinaryReader br)
        {
            throw new NotImplementedException();
        }
    }

    internal class TelemetryMessage
    {
    }
}
