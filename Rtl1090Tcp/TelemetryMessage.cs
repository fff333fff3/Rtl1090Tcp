using System;
using System.Collections.Generic;

namespace Rtl1090Tcp
{
    internal class TelemetryMessage
    {
        public BsTypeCode MessageType;
        public int TransmissionType;
        public int SessionId;
        public int AircraftId;
        public string HexId;
        public int FlightId;
        public DateTime DateTimeGenerated;
        public DateTime DateTimeLogged;

        public TelemetryMessage(BsTypeCode typeMessageType, IReadOnlyList<string> parts)
        {
            MessageType = typeMessageType;

            int.TryParse(parts[1], out TransmissionType);
            int.TryParse(parts[2], out SessionId);
            int.TryParse(parts[3], out AircraftId);
            HexId = parts[4];
            int.TryParse(parts[5], out FlightId);

            DateTime.TryParse($"{parts[6]} {parts[7]}", out DateTimeGenerated);
            DateTime.TryParse($"{parts[8]} {parts[9]}", out DateTimeLogged);
        }
    }
}