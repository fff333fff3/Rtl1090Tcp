namespace Rtl1090Tcp
{
    internal class TelemetryAirbornePositionGeometric : TelemetryMessage
    {
        public TelemetryAirbornePositionGeometric(int aircraftAddress, ADSBTypeCode typeCode, bool potentiallyCorrupt, byte[] dataBytes) : base(aircraftAddress, typeCode, potentiallyCorrupt)
        {
            // parse here
        }
    }
}