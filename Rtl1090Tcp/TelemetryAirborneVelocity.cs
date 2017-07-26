namespace Rtl1090Tcp
{
    internal class TelemetryAirborneVelocity : TelemetryMessage
    {
        public TelemetryAirborneVelocity(int aircraftAddress, ADSBTypeCode typeCode, bool potentiallyCorrupt, byte[] dataBytes) : base(aircraftAddress, typeCode, potentiallyCorrupt)
        {
            // parse here
        }
    }
}