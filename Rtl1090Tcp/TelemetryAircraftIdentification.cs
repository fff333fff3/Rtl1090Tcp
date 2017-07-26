namespace Rtl1090Tcp
{
    internal class TelemetryAircraftIdentification : TelemetryMessage
    {
        public TelemetryAircraftIdentification(int aircraftAddress, ADSBTypeCode typeCode, bool potentiallyCorrupt, byte[] dataBytes) : base(aircraftAddress, typeCode, potentiallyCorrupt)
        {
            // parse here
        }
    }
}