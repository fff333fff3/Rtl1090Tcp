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
                var signalLevel = br.ReadByte();

                TelemetryMessage message = null;

                switch (type)
                {
                    case 0x31:
                        message = DecodeModeAC(br);
                        break;
                    case 0x32:
                        message = DecodeShortModeS(br);
                        break;
                    case 0x33:
                        message = DecodeLongModeS(br);
                        break;
                }

                message?.SetWrapperData(type, time, signalLevel);

                return message;
            }
        }

        private static TelemetryMessage DecodeLongModeS(BinaryReader br)
        {
            var potentiallyCorrupt = false;

            var dfCa = br.ReadByte();
            var downlinkFormat = (dfCa & 0b11111000) >> 3;
            var capability = dfCa & 0b00000111;

            if (downlinkFormat != 17)
                potentiallyCorrupt = true;

            var icao = br.ReadBytes(3);
            var aircraftAddress = (icao[0] << 16) + (icao[1] << 8) + icao[2];

            var dataBytes = br.ReadBytes(7);
            var tc = (dataBytes[0] & 0b11111000) >> 3;
            dataBytes[0] = (byte)(dataBytes[0] & 0b00000111);

            var piBytes = br.ReadBytes(3);
            var parityIntegrator = (piBytes[0] << 16) + (piBytes[1] << 8) + piBytes[2];

            var typeCode = GetTypeCode(tc);

            if (typeCode == ADSBTypeCode.Unknown) // type code 0 is usually military
                potentiallyCorrupt = true;

            switch (typeCode)
            {
                case ADSBTypeCode.AircraftIdentification:
                    return new TelemetryAircraftIdentification(aircraftAddress, typeCode, potentiallyCorrupt, dataBytes);
                case ADSBTypeCode.SurfacePosition:
                    return new TelemetrySurfacePosition(aircraftAddress, typeCode, potentiallyCorrupt, dataBytes);
                case ADSBTypeCode.AirbornePositionBarometric:
                    return new TelemetryAirbornePositionBarometric(aircraftAddress, typeCode, potentiallyCorrupt, dataBytes);
                case ADSBTypeCode.AirborneVelocity:
                    return new TelemetryAirborneVelocity(aircraftAddress, typeCode, potentiallyCorrupt, dataBytes);
                case ADSBTypeCode.AirbornePositionGeometric:
                    return new TelemetryAirbornePositionGeometric(aircraftAddress, typeCode, potentiallyCorrupt, dataBytes);
            }

            return new TelemetryMessage(aircraftAddress, typeCode, potentiallyCorrupt);
        }

        private static ADSBTypeCode GetTypeCode(int tc)
        {
            if (tc >= 1 && tc <= 4)
                return ADSBTypeCode.AircraftIdentification;
            if (tc >= 5 && tc <= 8)
                return ADSBTypeCode.SurfacePosition;
            if (tc >= 9 && tc <= 18)
                return ADSBTypeCode.AirbornePositionBarometric;
            if (tc == 19)
                return ADSBTypeCode.AirborneVelocity;
            if (tc >= 20 && tc <= 22)
                return ADSBTypeCode.AirbornePositionGeometric;
            if (tc >= 23 && tc <= 31)
                return ADSBTypeCode.Reserved;
            return ADSBTypeCode.Unknown;
        }

        private static TelemetryMessage DecodeShortModeS(BinaryReader br)
        {
            return null;
        }

        private static TelemetryMessage DecodeModeAC(BinaryReader br)
        {
            return null;
        }
    }
}
