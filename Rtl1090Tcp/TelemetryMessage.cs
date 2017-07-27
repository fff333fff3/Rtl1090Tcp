namespace Rtl1090Tcp
{
    internal class TelemetryMessage
    {
        private byte[] _time;
        public byte MessageType { get; set; }
        public byte SignalLevel { get; set; }
        public int AircraftAddress { get; }
        public BsTypeCode Code { get; }
        public bool PotentiallyCorrupt { get; }

        public TelemetryMessage(int aircraftAddress, BsTypeCode typeCode, bool potentiallyCorrupt)
        {
            AircraftAddress = aircraftAddress;
            Code = typeCode;
            PotentiallyCorrupt = potentiallyCorrupt;
        }

        public void SetWrapperData(byte type, byte[] time, byte signalLevel)
        {
            MessageType = type;
            _time = time;
            SignalLevel = signalLevel;
        }
    }
}