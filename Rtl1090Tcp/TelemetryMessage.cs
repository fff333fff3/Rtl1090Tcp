using System;
using System.Collections.Generic;

namespace Rtl1090Tcp
{
    internal class TelemetryMessage
    {
        public BsTypeCode MessageType;
        public int TransmissionType;
        public TransmissionTypes TransmissionTypeName;
        public int SessionId;
        public int AircraftId;
        public string HexId;
        public int FlightId;
        public DateTime DateTimeGenerated;
        public DateTime DateTimeLogged;

        public TelemetryMessage(BsTypeCode typeMessageType, string[] parts)
        {
            MessageType = typeMessageType;

            int.TryParse(Util.Get(parts, 1), out TransmissionType);
            int.TryParse(Util.Get(parts, 2), out SessionId);
            int.TryParse(Util.Get(parts, 3), out AircraftId);
            HexId = Util.Get(parts, 4);
            int.TryParse(Util.Get(parts, 5), out FlightId);

            DateTime.TryParse($"{Util.Get(parts, 6)} {Util.Get(parts, 7)}", out DateTimeGenerated);
            DateTime.TryParse($"{Util.Get(parts, 8)} {Util.Get(parts, 9)}", out DateTimeLogged);

            if (TransmissionType != 0)
                TransmissionTypeName = (TransmissionTypes)TransmissionType;
        }
    }

    public enum TransmissionTypes
    {
        Invalid,
        IdentityAndCategory,
        SurfacePosition,
        AirbornePosition,
        AirborneVelocity,
        SurveillanceAltitude,
        SurveillanceIdentity,
        AirToAir,
        AllCallReply
    }
}