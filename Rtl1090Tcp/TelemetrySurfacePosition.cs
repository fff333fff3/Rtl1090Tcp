namespace Rtl1090Tcp
{
    internal class TelemetrySurfacePosition : TelemetryMessage
    {
        public TelemetrySurfacePosition(int aircraftAddress, ADSBTypeCode typeCode, bool potentiallyCorrupt, byte[] dataBytes) : base(aircraftAddress, typeCode, potentiallyCorrupt)
        {
            // parse here
        }
    }
}