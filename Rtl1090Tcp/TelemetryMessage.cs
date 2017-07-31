using System;
using System.Collections.Generic;

namespace Rtl1090Tcp
{
    internal class TelemetryMessage
    {
        public BsTypeCode MessageType;
        public int TransmissionTypeId;
        public TransmissionTypes TransmissionType;
        public int SessionId;
        public int AircraftId;
        public string HexId;
        public int FlightId;
        public DateTime DateTimeGenerated;
        public DateTime DateTimeLogged;

        public TelemetryMessage(BsTypeCode typeMessageType, string[] parts)
        {
            MessageType = typeMessageType;

            int.TryParse(Util.Get(parts, 1), out TransmissionTypeId);
            int.TryParse(Util.Get(parts, 2), out SessionId);
            int.TryParse(Util.Get(parts, 3), out AircraftId);
            HexId = Util.Get(parts, 4);
            int.TryParse(Util.Get(parts, 5), out FlightId);

            DateTime.TryParse($"{Util.Get(parts, 6)} {Util.Get(parts, 7)}", out DateTimeGenerated);
            DateTime.TryParse($"{Util.Get(parts, 8)} {Util.Get(parts, 9)}", out DateTimeLogged);

            if (TransmissionTypeId != 0)
                TransmissionType = (TransmissionTypes)TransmissionTypeId;
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