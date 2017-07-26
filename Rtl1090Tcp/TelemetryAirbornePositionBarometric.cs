namespace Rtl1090Tcp
{
    internal class TelemetryAirbornePositionBarometric : TelemetryMessage
    {
        public TelemetryAirbornePositionBarometric(int aircraftAddress, ADSBTypeCode typeCode, bool potentiallyCorrupt, byte[] dataBytes) : base(aircraftAddress, typeCode, potentiallyCorrupt)
        {
            // parse here
        }
    }
}