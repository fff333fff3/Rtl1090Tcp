using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtl1090Tcp
{
    class TrackedPlane
    {
        public int AircraftId;
        public string HexIdent;
        public int FlightId;
        public string Callsign;

        public int Altitude;
        public int GroundSpeed;
        public int GroundTrackAngle;
        public int Latitude;
        public int Longitude;
        public int VerticalRate;
        public int Squawk;
        public int Alert;
        public int Emergency;
        public int SpecialPositionIndicator;
        public int IsOnGround;

        public void Create(TelemetryMessage message)
        {
            AircraftId = message.AircraftId;
            HexIdent = message.HexId;
            FlightId = message.FlightId;
        }

        public void LoadMessage(TransmissionMessage message)
        {
            if (message.HasCallsign)
                Callsign = message.Callsign;
            if (message.HasAltitude)
                Altitude = message.Altitude;
            if (message.HasGroundSpeed)
                GroundSpeed = message.GroundSpeed;
            if (message.HasGroundTrackAngle)
                GroundTrackAngle = message.GroundTrackAngle;
            if (message.HasLatitude)
                Latitude = message.Latitude;
            if (message.HasLongitude)
                Longitude = message.Longitude;
            if (message.HasVerticalRate)
                VerticalRate = message.VerticalRate;
            if (message.HasSquawk)
                Squawk = message.Squawk;
            if (message.HasAlert)
                Alert = message.Alert;
            if (message.HasEmergency)
                Emergency = message.Emergency;
            if (message.HasSpecialPositionIndicator)
                SpecialPositionIndicator = message.SpecialPositionIndicator;
            if (message.HasIsOnGround)
                IsOnGround = message.IsOnGround;
        }
    }
}
