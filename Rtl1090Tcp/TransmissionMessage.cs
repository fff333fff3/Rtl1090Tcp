using System;
using System.Collections.Generic;
using System.IO;

namespace Rtl1090Tcp
{
    internal class TransmissionMessage : TelemetryMessage
    {
        public bool HasCallsign;
        public string Callsign;

        public bool HasAltitude;
        public int Altitude;

        public bool HasGroundSpeed;
        public int GroundSpeed;

        public bool HasGroundTrackAngle;
        public int GroundTrackAngle;

        public bool HasLatitude;
        public int Latitude;

        public bool HasLongitude;
        public int Longitude;

        public bool HasVerticalRate;
        public int VerticalRate;

        public bool HasSquawk;
        public int Squawk;

        public bool HasAlert;
        public int Alert;

        public bool HasEmergency;
        public int Emergency;

        public bool HasSpecialPositionIndicator;
        public int SpecialPositionIndicator;

        public bool HasIsOnGround;
        public int IsOnGround;

        public TransmissionMessage(string[] parts) : base(BsTypeCode.TransmissionMessage, parts)
        {
            if (TransmissionTypeName == TransmissionTypes.Invalid)
                throw new InvalidDataException();

            switch (TransmissionTypeName)
            {
                case TransmissionTypes.IdentityAndCategory:
                    // 10
                    break;
                case TransmissionTypes.SurfacePosition:
                    // 11, 12, 13, 14, 15, 21
                    break;
                case TransmissionTypes.AirbornePosition:
                    // 11, 14, 15, 18, 19, 20, 21
                    break;
                case TransmissionTypes.AirborneVelocity:
                    // 12, 13, 16
                    break;
                case TransmissionTypes.SurveillanceAltitude:
                    // 11, 18, 20, 21
                    break;
                case TransmissionTypes.SurveillanceIdentity:
                    // 11, 17, 18, 19, 20, 21
                    break;
                case TransmissionTypes.AirToAir:
                    // 11, 21
                    break;
                case TransmissionTypes.AllCallReply:
                    // 21
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            HasCallsign = Util.Get(parts, 0) == "";
            Callsign = Util.Get(parts, 10);

            HasAltitude = int.TryParse(Util.Get(parts, 11), out Altitude);
            HasGroundSpeed = int.TryParse(Util.Get(parts, 12), out GroundSpeed);
            HasGroundTrackAngle = int.TryParse(Util.Get(parts, 13), out GroundTrackAngle);
            HasLatitude = int.TryParse(Util.Get(parts, 14), out Latitude);
            HasLongitude = int.TryParse(Util.Get(parts, 15), out Longitude);
            HasVerticalRate = int.TryParse(Util.Get(parts, 16), out VerticalRate);
            HasSquawk = int.TryParse(Util.Get(parts, 17), out Squawk);
            HasAlert = int.TryParse(Util.Get(parts, 18), out Alert);
            HasEmergency = int.TryParse(Util.Get(parts, 19), out Emergency);
            HasSpecialPositionIndicator = int.TryParse(Util.Get(parts, 20), out SpecialPositionIndicator);
            HasIsOnGround = int.TryParse(Util.Get(parts, 21), out IsOnGround);
        }
    }
}