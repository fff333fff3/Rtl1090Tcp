using System;
using System.IO;

namespace Rtl1090Tcp
{
    internal class TransmissionMessage : TelemetryMessage
    {
        public TransmissionMessage(string[] parts) : base(BsTypeCode.TransmissionMessage, parts)
        {
            if (TransmissionTypeName == TransmissionTypes.Invalid)
                throw new InvalidDataException();

            switch (TransmissionTypeName)
            {
                case TransmissionTypes.IdentityAndCategory:
                    // 1
                    break;
                case TransmissionTypes.SurfacePosition:
                    // 3, 4, 5, 6, 7, 13
                    break;
                case TransmissionTypes.AirbornePosition:
                    // 2, 5, 6, 9, 10, 11, 12
                    break;
                case TransmissionTypes.AirborneVelocity:
                    // 3, 4, 7
                    break;
                case TransmissionTypes.SurveillanceAltitude:
                    // 2, 9, 11, 12
                    break;
                case TransmissionTypes.SurveillanceIdentity:
                    // 2, 8, 9, 10, 11, 12
                    break;
                case TransmissionTypes.AirToAir:
                    // 2, 12
                    break;
                case TransmissionTypes.AllCallReply:
                    // 12
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public enum MessageFields
        {
            /* 01 */ Callsign,
            /* 02 */ Altitude, // relative to 1013 mb
            /* 03 */ GroundSpeed,
            /* 04 */ GroundTrackAngle,
            /* 05 */ Latitude,
            /* 06 */ Longitude,
            /* 07 */ VerticalRate,
            /* 08 */ Squawk,
            /* 09 */ Alert,
            /* 10 */ Emergency,
            /* 11 */ SpecialPositionIndicator,
            /* 12 */ IsOnGround
        }
    }
}