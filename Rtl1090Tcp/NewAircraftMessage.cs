using System;

namespace Rtl1090Tcp
{
    internal class NewAircraftMessage : TelemetryMessage
    {
        public NewAircraftMessage(string[] parts) : base(BsTypeCode.NewAircraft, parts)
        {
        }
    }
}